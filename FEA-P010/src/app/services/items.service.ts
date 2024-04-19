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
      name: 'SSD Kingston NV2 1TB NVMe M.2 2280 (Leitura até 3500MB/s e Gravação até 2100MB/s)',
      inStock: true,
      price: 450,
      imageURL: 'https://m.media-amazon.com/images/I/71NfMZKkpQL._AC_AA180_.jpg'
    },
    {
      id: 2,
      name: 'Placa Mãe Gigabyte B550M AORUS Elite, Chipset B550, AMD AM4, mATX, DDR4',
      inStock: true,
      price: 744,
      imageURL: 'https://m.media-amazon.com/images/I/81QyMksmunL._AC_AA180_.jpg'
    },
    {
      id: 3,
      name: 'KF432C16BB/16 - Memória de 16GB DIMM DDR4 3200Mhz FURY Beast 1,35V 1Rx8 288 pinos para desktop/gamers, Preto',
      inStock: true,
      price: 299,
      imageURL: 'https://m.media-amazon.com/images/I/61MYgWr+xWL._AC_AA180_.jpg'
    },
    {
      id: 4,
      name: 'HD Externo 1TB USB 3.0 Seagate Expansion Portátil (STEA1000400)HD Externo 1TB USB 3.0 Seagate Expansion Portátil (STEA1000400)',
      inStock: true,
      price: 349.90,
      imageURL: 'https://m.media-amazon.com/images/I/51qRl0yBfAL._AC_AA180_.jpg'
    },
    {
      id: 5,
      name: 'Corsair Memória de computador compatível com Vengance RGB PRO DDR4 32 GB (2 x 16 GB) 3200 MHz CL16 Intel XMP 2.0 iCUE - Preto (CMW32GX4M2E3200C16)',
      inStock: true,
      price: 349.90,
      imageURL: 'https://m.media-amazon.com/images/I/71e6YWJio-L._AC_AA180_.jpg',
      properties: {
        color: 'Preto',
        capacity: '32GB (2x16GB)',
        style: '3200 MHz',
      }
    },
  ];

  constructor(private cartService: CartService) { }

  public addToCart(item: Item) {
    const _item: CartItem = { ...item, quantity: 1, gift: false };
    this.cartService.addItem(_item);
  }
}
