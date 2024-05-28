import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output, signal } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { UserService } from '../../services/user/user.service';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-add-user',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, ButtonModule, InputTextModule, DialogModule, ToastModule],
  providers: [MessageService],
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.css'
})
export class AddUserComponent {
  @Input() visible = signal(false);
  @Output() visibleChange: any = new EventEmitter();
  registerUserForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, private userService: UserService, private messageService: MessageService) { }

  async ngOnInit() {
    this.registerUserForm = this.formBuilder.group({
      'name': ["", [Validators.required]],
      'mail': ["", [Validators.required, Validators.email]],
      'birthDate': ["", [Validators.required]],
      'height': ["", [Validators.required]],
    });
  }

  public addUser() {
    if (this.registerUserForm.valid && this.registerUserForm.dirty) {
      this.userService.create(this.registerUserForm.value).then((res: any) => {
        if (!res.success) {
          switch (res.error.error.error.message) {
            case 'EMAIL_EXISTS':
              this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Este e-mail ja está cadastrado' });
              break;
            case 'OPERATION_NOT_ALLOWED':
              this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'O login por senha está desabilitado' });
              break;
            case 'TOO_MANY_ATTEMPTS_TRY_LATER':
              this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Muitas tentativas, tente mais tarde' });
              break;
          }
          return;
        }
        this.visible.set(false);
        this.visibleChange.emit();
      });
    }

    this.showErrors();
  }

  public showErrors() {
    this.showNameErrors();
    this.showMailErrors();
    this.showBirthDateErrors();
    this.showHeightErrors();
  }

  public showNameErrors() {
    let name = this.registerUserForm.get('name');
    if (name?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Nome obrigatório' });;
    }
  }

  public showMailErrors() {
    let mail = this.registerUserForm.get('mail');
    if (mail?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Email obrigatório' });
    }

    if (mail?.hasError('email')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Email inválido' });
    }
  }

  public showBirthDateErrors() {
    let birthDate = this.registerUserForm.get('birthDate');
    if (birthDate?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Data de nascimento obrigatória' });;
    }
  }

  public showHeightErrors() {
    let height = this.registerUserForm.get('height');
    if (height?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Altura obrigatória' });
    }

    if (parseFloat(height?.value) < 0 || parseFloat(height?.value) > 3) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Digite uma altura válida' });
    }
  }
}
