import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../models/Usuario/UsuarioViewModel';
import { BehaviorSubject, catchError, tap, throwError } from 'rxjs';
import { AuthResponse } from '../models/Auth/AuthResponse';
import Swal from 'sweetalert2';
import { env } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly loginUrl = `${env.auth.baseUrl}:signInWithPassword?key=${env.auth.apiKey}`;
  private readonly signupUrl = `${env.auth.baseUrl}:signUp?key=${env.auth.apiKey}`;

  usuario = new BehaviorSubject<Usuario>(new Usuario('', '', '', new Date()));

  constructor(private http: HttpClient) { }

  signupUser(email: string, password: string) {
    return this.http.post<AuthResponse>(this.signupUrl,
      {
        email: email,
        password: password,
        returnSecureToken: true
      }).pipe(
        tap(response => {
          const expiracaoData = new Date(new Date().getTime() + (parseInt(response.expiresIn) * 1000));
          const usuario = new Usuario(
            response.email,
            response.localId,
            response.idToken,
            expiracaoData
          );

          this.usuario.next(usuario);
          localStorage.setItem('user', JSON.stringify(usuario));
        }),
        catchError(error => {
          console.error(error);
          Swal.fire({
            icon: 'error',
            title: 'Erro!',
            text: 'Ocorreu um erro ao realizar seu registro. Por favor, tente novamente.'
          });
          return throwError(error);
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
        tap(res => {
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
        catchError(error => {
          console.error(error);
          Swal.fire({
            icon: 'error',
            title: 'Erro!',
            text: 'Ocorreu um erro ao realizar seu login. Por favor, tente novamente.'
          });
          return throwError(error);
        })
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
