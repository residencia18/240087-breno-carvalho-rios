import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  let loggedIn: boolean = false;

  authService.autoLogin();

  authService.usuario.subscribe((usuario) => {
    loggedIn = usuario.token ? true : false;
  });

  if (!loggedIn) {
    router.navigate(['/auth/login']);
  }

  return loggedIn;
};
