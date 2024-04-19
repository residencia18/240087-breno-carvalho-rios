import { Component, Signal, computed, effect, signal } from '@angular/core';
import { CartItemComponent } from '../cart-item/cart-item.component';
import { Item } from '../../interfaces/Item';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [
    CommonModule,
    CartItemComponent,
    ButtonModule
  ],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  constructor(public service: CartService) { }

  total = computed(() => this.service.items().reduce((total, item) => total + item.price * item.quantity, 0));
  quantity = computed(() => this.service.items().reduce((total, item) => total + item.quantity, 0));
}
