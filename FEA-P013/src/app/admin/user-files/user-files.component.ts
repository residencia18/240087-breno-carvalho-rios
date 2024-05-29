import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { UserService } from '../../services/user/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-user-files',
  standalone: true,
  imports: [CommonModule, ButtonModule, TableModule, ConfirmDialogModule, ToastModule],
  providers: [ConfirmationService, MessageService],
  templateUrl: './user-files.component.html',
  styleUrl: './user-files.component.css'
})
export class UserFilesComponent {
  public readonly userId = this.route.snapshot.paramMap.get('id');

  public user: any = {};
  private _files: any[] = [];

  public files: any[] = [];


  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) { }

  async ngOnInit() {
    if (!this.userId) {
      this.router.navigate(['/admin/users']);
      return;
    }
    await this.fetch();
  }

  async confirmDeleteFile(trainingId: string, filename: string, originalName: string) {
    this.confirmationService.confirm({
      message: `<p>Deseja realmente excluir o arquivo abaixo?</p> <p class="bold underlined">${originalName}</p>`,
      accept: () => {
        this.deleteFile(trainingId, filename);
      }
    });
  }

  private async deleteFile(trainingId: string, filename: string) {
    await this.userService.deleteFileObject(this.userId!, filename);
    await this.userService.deleteTraining(this.userId!, trainingId);
    await this.fetch();
    this.messageService.add({ severity: 'success', summary: 'Arquivo excluído', detail: 'Arquivo excluído com sucesso' });
  }

  public async fetch() {
    this.user = await this.userService.getById(this.userId!);
    this._files = await this.userService.getFilesById(this.userId!);

    this.files = this._files;
  }
}
