import { Component, EventEmitter, Input, Output, ViewChild, signal } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../services/user/user.service';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { Dialog, DialogModule } from 'primeng/dialog';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-edit-user',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, ButtonModule, InputTextModule, DialogModule],
  providers: [MessageService],
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.css'
})


export class EditUserComponent {
  @Input() visible = signal(false);
  @Input() user: any = signal({});
  @Output() visibleChange: any = new EventEmitter();

  editUserForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, private userService: UserService, private messageService: MessageService) { }

  async ngOnInit() {
    this.editUserForm = this.formBuilder.group({
      'name': [null, []],
      'mail': [null, []],
      'birthDate': [null, []],
      'height': [null, []],
    });
  }

  patchValue() {
    this.editUserForm.patchValue(this.user());
  }

  resetForm() {
    this.editUserForm.reset();
  }

  public updateUser() {
    if (this.editUserForm.valid && this.editUserForm.dirty) {
      this.userService.update(this.user().id, this.editUserForm.value).then(() => {
        console.log("Usuário editado com sucesso");
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
    let name = this.editUserForm.get('name');
    if (name?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Nome obrigatório' });;
    }
  }

  public showMailErrors() {
    let mail = this.editUserForm.get('mail');
    if (mail?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Email obrigatório' });
    }

    if (mail?.hasError('email')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Email inválido' });
    }
  }

  public showBirthDateErrors() {
    let birthDate = this.editUserForm.get('birthDate');
    if (birthDate?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Data de nascimento obrigatória' });;
    }
  }

  public showHeightErrors() {
    let height = this.editUserForm.get('height');
    if (height?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Altura obrigatória' });
    }

    if (parseFloat(height?.value) < 0 || parseFloat(height?.value) > 3) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Digite uma altura válida' });
    }
  }
}
