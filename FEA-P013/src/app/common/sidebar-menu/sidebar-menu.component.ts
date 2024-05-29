import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { AuthService } from '../../services/auth/auth.service';
import { UserService } from '../../services/user/user.service';

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

  public user: any = this.authService.getUser();

  constructor(private userService: UserService) {
    if (!this.user) {
      this.router.navigate(['/auth/login']);
      return;
    }

    this.userService.getByLoginId(this.user.uid).then((user: any) => {
      this.user.admin = user.admin || false;
    });
  }

  menuGroups: any[] = [
    {
      name: 'Administrador',
      admin: true,
      items: [
        { label: 'Usuários', routerLink: '/admin/users' },
      ] as MenuItem[],
    },
    {
      name: 'Usuário',
      admin: false,
      items: [
        { label: 'Perfil', routerLink: '/me/profile' },
        { label: 'Arquivos', routerLink: '/me/files' },
      ] as MenuItem[],
    },
    {
      name: 'Outros',
      admin: false,
      items: [
        { label: 'Guia', routerLink: '/help' },
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
