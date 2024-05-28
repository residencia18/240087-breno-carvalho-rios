import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output, ViewChild, ViewEncapsulation, signal } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { FileUpload, FileUploadModule } from 'primeng/fileupload';
import { UserService } from '../../services/user/user.service';
import { ProgressBarModule } from 'primeng/progressbar';
import { getDownloadURL } from '@angular/fire/storage';

@Component({
  selector: 'app-upload-file',
  standalone: true,
  imports: [CommonModule, ButtonModule, DialogModule, FileUploadModule, ProgressBarModule],
  providers: [FileUpload],
  templateUrl: './upload-file.component.html',
  styleUrl: './upload-file.component.css',
  encapsulation: ViewEncapsulation.None
})
export class UploadFileComponent {
  @ViewChild('fileUpload') fileUpload!: FileUpload;

  @Input() visible = signal(false);
  @Input() userId = signal("");
  @Output() visibleChange: any = new EventEmitter();

  public progress = 0;

  constructor(private _userService: UserService) { }

  uploadFile() {
    if (!this.userId() || this.fileUpload.files.length < 1) {
      return;
    }

    this.progress = 0;
    let uploadTask = this._userService.uploadFile(this.userId(), this.fileUpload.files[0])

    uploadTask.on('state_changed',
      (snapshot: any) => {
        this.progress = Math.round((snapshot.bytesTransferred / snapshot.totalBytes) * 100);
      },
      (error) => { console.log(error); },
      () => {
        getDownloadURL(uploadTask.snapshot.ref).then((downloadURL) => {
          this._userService.createTraining(this.userId(),
            {
              name: uploadTask.snapshot.ref.name,
              originalName: this.fileUpload.files[0].name,
              url: downloadURL,
              createdAt: new Date().toLocaleDateString('pt-BR')
            }
          ).then(() => {
            setTimeout(() => {
              this.visibleChange.emit();
              this.closeDialog();
            }, 500);
          })
        });
      }
    )
  }

  choose() {
    this.fileUpload.choose();
  }

  closeDialog() {
    this.fileUpload.clear();
    this.userId.set("");
    this.visible.set(false);
  }
}
