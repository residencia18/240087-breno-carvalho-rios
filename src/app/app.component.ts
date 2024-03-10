import { Component } from '@angular/core';
import { MenuItem, PrimeNGConfig } from 'primeng/api';
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

  constructor(private authService: AuthService, private router: Router, private config: PrimeNGConfig) {
    this.authService.usuario.subscribe((usuario) => {
      this.loggedIn = usuario.token ? true : false;
      this.menuItems = [
        { label: "Inicio", routerLink: '/' },
        { label: "Cadastrar Suíno", routerLink: '/suinos/novo' }
      ]
    })
  }

  ngOnInit() {
    this.config.setTranslation({
      monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
      monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
      dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
      dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
      dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
    });
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/auth/login']);
  }
}
