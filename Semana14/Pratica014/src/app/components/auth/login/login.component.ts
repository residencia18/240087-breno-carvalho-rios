import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  public error: string = '';
  constructor(private authService: AuthService, private router: Router) { }
  
  loginForm: FormGroup = new FormGroup({
    email: new FormControl(null, Validators.required),
    password: new FormControl(null, Validators.required),
  });

  submit() {
    if (this.loginForm.valid) {
      this.authService.loginUser(
        this.loginForm.value.email,
        this.loginForm.value.password
      ).subscribe({
        next: () => {
          this.router.navigate(['/']);
        },
        error: response => {
          const error = response.error.error;
          console.log(error.message);
          if (error.message = "INVALID_LOGIN_CREDENTIALS" || error.message === "EMAIL_NOT_FOUND" || error.message === "INVALID_PASSWORD") {
            this.error = "Email ou senha incorretos!";
          }
        }
      });
    }
  }
}
