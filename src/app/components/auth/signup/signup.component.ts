import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  public error: string = '';
  constructor(private authService: AuthService, private router: Router) { }

  signupForm: FormGroup = new FormGroup({
    email: new FormControl(null, [Validators.required, Validators.email, Validators.minLength(10)]),
    password: new FormControl(null, [Validators.required, Validators.minLength(4), Validators.pattern(/^(?=.*[A-Z])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{4,}$/)]),
  });

  submit() {
    if (this.signupForm.valid) {
      this.error = '';
      this.authService.signupUser(
        this.signupForm.value.email,
        this.signupForm.value.password
      ).subscribe({
        next: () => {
          Swal.fire({
            title: 'Sucesso !',
            icon: 'success',
            showConfirmButton: false,
            timer: 2000
          })
          this.router.navigate(['/']);
        },
        error: response => {
          const error = response.error.error;
          if (error.message == "EMAIL_EXISTS") {
            Swal.fire({
              title: 'Error !',
              icon: 'error',
              text: 'Email já cadastrado! Por favor, tente novamente.',
              showConfirmButton: true,
            })
          }
          if (error.message == "TOO_MANY_ATTEMPTS_TRY_LATER") {
            this.error = "Muitas tentativas, tente mais tarde!";
          }
        }
      });
    } else {
      Swal.fire({
        title: 'Error !',
        icon: 'error',
        text: 'Oppss... Houve um error ao enviar o formulário, verifique os  campos e tente novamente.',
        showConfirmButton: true,

      })
      console.error('Por favor, corrija os erros no formulário.');
    }
  }

}
