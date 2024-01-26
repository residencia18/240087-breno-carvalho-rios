import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Pratica009';
  items: MenuItem[] = [
    { label: 'Aula 3 - Agência de Turismo', routerLink: '/turismo' },
    { label: 'Aula 6 - Página da UESC', routerLink: '/uesc' },
    { label: 'Aula 8 - Pesquisa Wikipedia', routerLink: '/wikipedia' }
  ]
}
