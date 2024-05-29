import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-sidebar-menu',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './sidebar-menu.component.html',
  styleUrl: './sidebar-menu.component.css'
})
export class SidebarMenuComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  menuGroups: any[] = [
    {
      name: 'Administrador',
      items: [
        { label: 'Usuários', routerLink: '/admin/users' },
      ] as MenuItem[],
    },
    {
      name: 'Usuário',
      items: [
        { label: 'Perfil', routerLink: '/me/profile' },
        { label: 'Arquivos', routerLink: '/me/files' },
      ] as MenuItem[],
    }
  ];

  navigate(routerLink: string) {
    this.router.navigate([routerLink]);
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/auth/login']);
  }
}
