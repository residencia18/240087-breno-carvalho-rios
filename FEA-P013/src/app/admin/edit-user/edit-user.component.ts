import { Component, EventEmitter, Input, Output, ViewChild, signal } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../services/user/user.service';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { DialogModule } from 'primeng/dialog';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-edit-user',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, ButtonModule, InputTextModule, DialogModule, ToastModule],
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
      'name': ["", [Validators.required]],
      'birthDate': ["", [Validators.required]],
      'height': ["", [Validators.required, this.heightValidator.bind(this)]],
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
        this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: 'Usário atualizado com sucesso' });
        this.visible.set(false);
        this.visibleChange.emit();
      });
    }
    this.showErrors();
  }

  public showErrors() {
    this.showNameErrors();
    this.showBirthDateErrors();
    this.showHeightErrors();
  }

  public showNameErrors() {
    let name = this.editUserForm.get('name');
    if (name?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Nome obrigatório' });;
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
    console.log(height?.value);

    if (height?.hasError('required')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Altura obrigatória' });
    }

    if (height?.hasError('invalidHeight')) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Altura inválida' });
    }

    if (parseFloat(height?.value) < 0 || parseFloat(height?.value) > 3) {
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Altura inválida' });
    }
  }

  public heightValidator(control: any) {
    if (isNaN(control.value)) {
      return { 'invalidHeight': true };
    }

    return null;
  }
}
