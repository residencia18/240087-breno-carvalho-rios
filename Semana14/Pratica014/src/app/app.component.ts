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
  title = 'Pratica014';
  menuItems: MenuItem[] = []
  public loggedIn = false;

  constructor(private authService: AuthService, private router: Router) {
    this.authService.usuario.subscribe((usuario) => {
      this.loggedIn = usuario.token ? true : false;
      this.menuItems = [
        { label: "Inicio", routerLink: '/' },
        { label: "Criar Atendimento", routerLink: '/atendimentos/novo' },
        { label: "Logout", command: () => {
          this.authService.logout();
          this.router.navigate(['/auth/login']);
        }},
      ]
    })
  }
}
