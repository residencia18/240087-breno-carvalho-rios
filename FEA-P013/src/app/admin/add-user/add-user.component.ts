import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-add-user',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, ButtonModule, InputTextModule, DialogModule],
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.css'
})
export class AddUserComponent {
  @Input() visible: any;
  registerUserForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, private userService: UserService) { }

  async ngOnInit() {
    this.registerUserForm = this.formBuilder.group({
      'name': [null, []],
      'mail': [null, []],
      'birthDate': [null, []],
      'height': [null, []],
    });
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
