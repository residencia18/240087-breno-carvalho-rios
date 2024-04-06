import { NgModule } from '@angular/core';
import { AuthComponent } from './components/auth.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { SharedModule } from '../shared/shared.module';
import { AuthRoutingModule } from './auth-routing.module';


@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    SignupComponent
  ],
  imports: [
    AuthRoutingModule,
    SharedModule,
    ButtonModule,
    InputTextModule
  ]
})
export class AuthModule { }
