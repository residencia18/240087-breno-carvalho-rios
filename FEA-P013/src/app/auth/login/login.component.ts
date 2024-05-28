import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { AuthService } from '../../services/auth/auth.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, ReactiveFormsModule, ButtonModule, InputTextModule, ToastModule],
  providers: [MessageService],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router, private messageService: MessageService) { }
  loginForm: FormGroup = new FormGroup({});

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      'email': [null, [Validators.required, Validators.email]],
      'password': [null, [Validators.required, Validators.minLength(8)]],
    });
  }

  submit() {
    if (this.loginForm.valid) {
      this.authService.loginUser2(this.loginForm.value.email, this.loginForm.value.password);
      // this.authService.loginUser(this.loginForm.value.email, this.loginForm.value.password).subscribe({
      //   next: (res) => {
      //     this.messageService.add({ severity: 'success', summary: 'Login', detail: 'Login realizado com sucesso' });
      //     this.router.navigate(['/']);
      //   },
      //   error: (error) => {
      //     switch (error.error.error.message) {
      //       case 'EMAIL_NOT_FOUND':
      //         this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'E-mail não encontrado' });
      //         break;
      //       case 'INVALID_PASSWORD':
      //         this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Senha inválida' });
      //         break;
      //       case 'INVALID_LOGIN_CREDENTIALS':
      //         this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Dados de login inválidos' });
      //         break;
      //       case 'TOO_MANY_ATTEMPTS_TRY_LATER':
      //         this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Muitas tentativas, tente mais tarde' });
      //         break;
      //       case 'USER_DISABLED':
      //         this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Conta desativada' });
      //         break;
      //     }
      //   }
      // });
    }
  }

  forgotPassword() {
    console.log('Desculpe, ainda não está funcionando');
  }
}
