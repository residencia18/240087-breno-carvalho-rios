import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Pratica013';
  menuItems: MenuItem[] = [
    { label: "Inicio", routerLink: '/' },
    { label: "Criar Atendimento", routerLink: '/novo/atendimento' },
  ]
}
