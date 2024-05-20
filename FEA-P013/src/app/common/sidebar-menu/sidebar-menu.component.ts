import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-sidebar-menu',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './sidebar-menu.component.html',
  styleUrl: './sidebar-menu.component.css'
})
export class SidebarMenuComponent {
  menuGroups: any[] = [
    {
      name: 'Administrador',
      items: [
        { label: 'Usuários', routerLink: '#' },
      ] as MenuItem[],
    },
    {
      name: 'Usuário',
      items: [
        { label: 'Perfil', routerLink: '#' },
        { label: 'Arquivos', routerLink: '#' },
      ] as MenuItem[],
    },
    {
      name: 'Conta',
      items: [
        { label: 'Sair', routerLink: '#' }
      ] as MenuItem[],
    },
  ];
}
