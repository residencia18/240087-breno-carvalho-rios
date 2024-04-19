import { Component, Input } from '@angular/core';
import { Item } from '../../interfaces/Item';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ItemsService } from '../../services/items.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ButtonModule
  ],
  templateUrl: './item.component.html',
  styleUrl: './item.component.css'
})
export class ItemComponent {
  @Input() item: Item = {} as Item;

  constructor(public service: ItemsService, private router: Router) { }

  public addToCart() {
    this.service.addToCart(this.item);
    this.router.navigate(['/carrinho']);
  }
}
