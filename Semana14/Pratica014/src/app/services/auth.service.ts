import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../models/Usuario/UsuarioViewModel';
import { BehaviorSubject, tap } from 'rxjs';
import { AuthResponse } from '../models/Auth/AuthResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiKey = '...';
  private readonly baseUrl = `https://identitytoolkit.googleapis.com/v1/accounts`;
  private readonly loginUrl = `${this.baseUrl}:signInWithPassword?key=${this.apiKey}`;
  private readonly signupUrl = `${this.baseUrl}:signUp?key=${this.apiKey}`;

  usuario = new BehaviorSubject<Usuario>(new Usuario('', '', '', new Date()));

  constructor(private http: HttpClient) { }

  signupUser(email: string, password: string) {
    return this.http.post<AuthResponse>(this.signupUrl,
      {
        email: email,
        password: password,
        returnSecureToken: true
      }).pipe(
        tap((response: AuthResponse) => {
          const expiracaoData = new Date(new Date().getTime() + (parseInt(response.expiresIn) * 1000));
          const usuario = new Usuario(
            response.email,
            response.localId,
            response.idToken,
            expiracaoData
          );

          this.usuario.next(usuario);
          localStorage.setItem('user', JSON.stringify(usuario));
        })
      );
  }

  loginUser(email: string, password: string) {
    return this.http.post<AuthResponse>(this.loginUrl,
      {
        email: email,
        password: password,
        returnSecureToken: true
      }).pipe(
        tap((res: AuthResponse) => {
          const expiracaoData = new Date(new Date().getTime() + (parseInt(res.expiresIn) * 1000));
          const usuario = new Usuario(
            res.email,
            res.localId,
            res.idToken,
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

    const loadedUser = new Usuario(
      userData.email,
      userData.id,
      userData._token,
      new Date(userData._tokenExpirationDate)
    );

    if (loadedUser.token) {
      this.usuario.next(loadedUser);
    }
  }

  logout() {
    this.usuario.next(new Usuario('', '', '', new Date()));
    localStorage.removeItem('user');
  }
}
