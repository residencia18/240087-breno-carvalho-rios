import { Component, ViewEncapsulation, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user/user.service';
import { AddUserComponent } from '../add-user/add-user.component';
import { UploadFileComponent } from '../upload-file/upload-file.component';
import { EditUserComponent } from '../edit-user/edit-user.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Router, RouterModule } from '@angular/router';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    TableModule,
    InputIconModule,
    IconFieldModule,
    InputTextModule,
    ButtonModule,
    AddUserComponent,
    EditUserComponent,
    UploadFileComponent,
    ConfirmDialogModule,
    ToastModule
  ],
  providers: [ConfirmationService, MessageService],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
})
export class UserListComponent {
  public userId = signal("");
  public user: any = signal({});
  public addUserDialogVisible = signal(false);
  public editUserDialogVisible = signal(false);
  public uploadFileDialogVisible = signal(false);

  private _users: any[] = [];
  public users: any[] = [];

  public search: string = "";

  constructor(private userService: UserService, private confirmationService: ConfirmationService, private messageService: MessageService) { }

  async ngOnInit() {
    this.fetch();
  }

  public filterUserList() {
    this.users = this._users.filter(user => user.name.toUpperCase().includes(this.search.toUpperCase()));
  }

  public showEditUserDialog(user: any) {
    this.user.set(user);
    this.editUserDialogVisible.set(true);
  }

  public showUploadFileDialog(id: string) {
    this.userId.set(id);
    this.uploadFileDialogVisible.set(true);
  }

  private deleteUser(id: string) {
    this.userService.delete(id).then(() => {
      this.fetch();
    })
  }

  confirmDeleteUser(id: string, name: string) {
    this.confirmationService.confirm({
      message: `<p>Deseja realmente excluir o usuário abaixo?</p> <p class="bold underlined">${name}</p>`,
      accept: () => {
        this.deleteUser(id);
        this.messageService.add({ severity: 'success', summary: 'Usuário excluído', detail: 'Usuário excluído com sucesso' });
      }
    });
  }

  public async fetch() {
    this._users = await this.userService.getAll();
    this.users = this._users;
  }

  getLastFile(user: any) {
    if (user.trainings && user.trainings.length > 0) {
      return user.trainings.at(0);
    }
    else {
      return {
        name: '',
        url: '',
        createdAt: ''
      };
    }
  }
}
