import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { SidebarMenuComponent } from '../sidebar-menu/sidebar-menu.component';
import { RouterModule, RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-main',
  standalone: true,
  imports: [CommonModule, RouterModule, RouterOutlet, SidebarMenuComponent, ButtonModule],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent {
  menuIsOpen: boolean = false;
}
