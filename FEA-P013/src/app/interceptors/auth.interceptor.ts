import { Injectable, inject } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpParams
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth/auth.service';
@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let usuario: any = this.authService.getUser();

    if (!usuario) {
      return next.handle(request);
    }

    const requestModificado = request.clone({
      params: new HttpParams().set('auth', usuario.stsTokenManager.accessToken!)
    });
    return next.handle(requestModificado);
  }
}
