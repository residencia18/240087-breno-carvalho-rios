import { Component, EventEmitter, Input, Output, effect } from '@angular/core';
import { InputNumberModule } from 'primeng/inputnumber';
import { Item } from '../../interfaces/Item';
import { FormsModule } from '@angular/forms';
import { CheckboxModule } from 'primeng/checkbox';
import { CommonModule } from '@angular/common';
import { CartItem } from '../../interfaces/CartItem';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart-item',
  standalone: true,
  imports: [
    CommonModule,
    InputNumberModule,
    CheckboxModule,
    FormsModule
  ],
  templateUrl: './cart-item.component.html',
  styleUrl: './cart-item.component.css'
})
export class CartItemComponent {
  @Input() item: CartItem = {} as CartItem;

  constructor(private cartService: CartService) { }

  removeItem() {
    this.cartService.removeItem(this.item.id);
  }

  quantityChange() {
    if (this.item.quantity <= 0 || this.item.quantity > 999) {
      this.item.quantity = 1;
    }
    this.updateItem();
  }

  onGiftChange() {
    this.updateItem();
  }

  updateItem() {
    this.cartService.updateItem(this.item);
  }
}
