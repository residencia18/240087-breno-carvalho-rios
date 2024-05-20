import { Component, ViewEncapsulation, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { UserService } from '../../services/user/user.service';
import { firstValueFrom } from 'rxjs';
import { AddUserComponent } from '../add-user/add-user.component';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, TableModule, InputIconModule, IconFieldModule, InputTextModule, ButtonModule, DialogModule, AddUserComponent],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
})
export class UserListComponent {
  public addUserVisible = signal(false);
  private _userId = signal(0);
  public registerUserDialogVisible = false;
  public uploadFileDialogVisible = false;
  public search: string = "";

  registerUserForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, private userService: UserService) { }

  async ngOnInit() {
    this.registerUserForm = this.formBuilder.group({
      'name': [null, []],
      'mail': [null, []],
      'birthDate': [null, []],
      'height': [null, []],
    });

    this.users = await this.userService.getAll();
    console.log(this.users);
  }

  private _users: any[] = [];

  public users = this._users;

  public filterUserList() {
    this.users = this._users.filter(user => user.name.includes(this.search));
  }

  public uploadFile(id: number) {
    this._userId.set(id);
    this.uploadFileDialogVisible = true;
  }

  public registerUser() {
    if (this.registerUserForm.valid) {
      console.log(this.registerUserForm.value);
      this.userService.create(this.registerUserForm.value).then(() => {
        console.log("Usuário criado com sucesso");
      });
    }
  }
}
