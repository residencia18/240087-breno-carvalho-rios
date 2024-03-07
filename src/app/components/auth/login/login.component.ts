import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  public error: string = '';
  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) { }
  loginForm: FormGroup = new FormGroup({});

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      'email': [null, [Validators.required, Validators.email, Validators.minLength(10)]],
      'password': [null, [Validators.required, Validators.minLength(4), Validators.pattern(/^(?=.*[A-Z])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{4,}$/)]],
    });
  }

  submit(form: FormGroup) {

    if (this.loginForm.valid) {
      this.authService.loginUser(form.value.email, form.value.password).subscribe((res) => {
        Swal.fire({
          title: 'Sucesso !',
          icon: 'success',
          showConfirmButton: false,
          timer: 2000
        })
        setTimeout(() => {
          this.router.navigate(['/'])

        }, 2300)
      })
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
