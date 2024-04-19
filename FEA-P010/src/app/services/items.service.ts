import { Injectable, signal } from '@angular/core';
import { CartService } from './cart.service';
import { Item } from '../interfaces/Item';
import { CartItem } from '../interfaces/CartItem';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  public readonly items = [
    {
      id: 1,
      name: 'Item 1',
      gift: false,
      inStock: true,
      price: 10.99,
      quantity: 1,
      imageURL: 'https://picsum.photos/200/300',
    },
    {
      id: 2,
      name: 'Item 2',
      gift: false,
      inStock: false,
      price: 20.99,
      quantity: 2,
      imageURL: 'https://picsum.photos/200/301',
      properties: {
        capacity: "32GB",
        color: "Preto",
        style: "3200MHz"
      },
    },
    {
      id: 3,
      name: 'Item 3',
      gift: false,
      inStock: true,
      price: 30.99,
      quantity: 3,
      imageURL: 'https://picsum.photos/200/302',
    },
    {
      id: 4,
      name: 'Item 4',
      gift: false,
      inStock: false,
      price: 40.99,
      quantity: 4,
      imageURL: 'https://picsum.photos/200/303',
      properties: {
        capacity: "32GB",
        color: "Preto",
        style: "3200MHz"
      },
    },
    {
      id: 5,
      name: 'Item 5',
      gift: true,
      inStock: true,
      price: 50.99,
      quantity: 5,
      imageURL: 'https://picsum.photos/200/304',
      properties: {
        capacity: "32GB",
        color: "Preto",
        style: "3200MHz"
      },
    }
  ];

  constructor(private cartService: CartService) { }

  public addToCart(item: Item) {
    let _item = { ...item, quantity: 1, gift: false };
    this.cartService.addItem(_item);
  }
}
