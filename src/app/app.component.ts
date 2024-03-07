import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Pratica015';
  menuItems: MenuItem[] = []
  public loggedIn = false;

  constructor(private authService: AuthService, private router: Router) {
    this.authService.usuario.subscribe((usuario) => {
      this.loggedIn = usuario.token ? true : false;
      this.menuItems = [
        { label: "Inicio", routerLink: '/' },
        { label: "Cadastrar Suíno", routerLink: '/suinos/novo' }
      ]
    })
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/auth/login']);
  }
}
