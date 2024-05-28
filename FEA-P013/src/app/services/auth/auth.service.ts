import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User } from '../../../models/User';
import { AuthResponse } from '../../../models/AuthResponse';
import { getAuth, signInWithEmailAndPassword } from '@angular/fire/auth';
import { FirebaseApp } from '@angular/fire/app';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly loginUrl = `https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${environment.firebaseConfig.apiKey}`;
  private readonly signupUrl = `https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=${environment.firebaseConfig.apiKey}`;
  private readonly forgotPasswordUrl = `https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=${environment.firebaseConfig.apiKey}`;

  private readonly auth = getAuth(this.app);

  usuario = new BehaviorSubject<User>(new User('', '', '', new Date()));

  constructor(private http: HttpClient, private app: FirebaseApp) { }

  loginUser(email: string, password: string) {
    return this.http.post<AuthResponse>(this.loginUrl,
      {
        email: email,
        password: password,
        returnSecureToken: true
      }).pipe(
        tap(res => {
          const expiracaoData = new Date(new Date().getTime() + (parseInt(res.expiresIn) * 1000));
          const usuario = new User(
            res.email,
            res.localId,
            res.idToken,
            expiracaoData
          );
          this.usuario.next(usuario);
          localStorage.setItem('user', JSON.stringify(usuario));
        })
      );
  }

  loginUser2(email: string, password: string) {
    signInWithEmailAndPassword(this.auth, email, password).then((userCredential) => {
      console.log(this.auth.currentUser?.email)
    });
  }

  signupUser(email: string) {
    let password = this.generateRandomPassword();

    return this.http.post<AuthResponse>(this.signupUrl,
      {
        email: email,
        password: password,
        returnSecureToken: true
      }).pipe(
        tap(response => {
          const expiracaoData = new Date(new Date().getTime() + (parseInt(response.expiresIn) * 1000));
          const usuario = new User(
            response.email,
            response.localId,
            response.idToken,
            expiracaoData
          );

          this.usuario.next(usuario);
          localStorage.setItem('user', JSON.stringify(usuario));
        }),
      );
  }

  autoLogin() {
    const userData: {
      email: string;
      id: string;
      _token: string;
      _tokenExpirationDate: string;

    } = JSON.parse(localStorage.getItem('user') as string);
    if (!userData) {
      return;
    }

    const loadedUser = new User(
      userData.email,
      userData.id,
      userData._token,
      new Date(userData._tokenExpirationDate)
    );

    if (loadedUser.token) {
      this.usuario.next(loadedUser);
    }
  }

  // getUser() {
  //   const userData: {
  //     email: string;
  //     id: string;
  //     _token: string;
  //     _tokenExpirationDate: string;

  //   } = JSON.parse(localStorage.getItem('user') as string);
  //   if (!userData) {
  //     return;
  //   }

  //   const loadedUser = new User(
  //     userData.email,
  //     userData.id,
  //     userData._token,
  //     new Date(userData._tokenExpirationDate)
  //   );
  // }

  sendRecoveryPassword(email: string) {
    return this.http.post(this.forgotPasswordUrl, {
      requestType: "PASSWORD_RESET",
      email: email
    });
  }

  logout() {
    this.usuario.next(new User('', '', '', new Date()));
    localStorage.removeItem('user');
  }

  generateRandomPassword() {
    return Math.random().toString(36).slice(-8);
  }
}
