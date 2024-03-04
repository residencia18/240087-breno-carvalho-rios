import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  public error: string = '';
  constructor(private authService: AuthService, private router: Router) { }

  signupForm: FormGroup = new FormGroup({
    email: new FormControl(null, [Validators.required, Validators.email]),
    password: new FormControl(null, [Validators.required, Validators.minLength(6)]),
  });

  submit(){
    if(this.signupForm.valid){
      this.error = '';
      this.authService.signupUser(
        this.signupForm.value.email,
        this.signupForm.value.password
      ).subscribe({
        next: () => {
          this.router.navigate(['/']);
        },
        error: response => {
          const error = response.error.error;
          if (error.message == "EMAIL_EXISTS"){
            this.error = "Email já cadastrado!";
          }
          if (error.message == "TOO_MANY_ATTEMPTS_TRY_LATER"){
            this.error = "Muitas tentativas, tente mais tarde!";
          }
        }
      });
    }
  }
}
