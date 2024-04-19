import { Component } from '@angular/core';
import { ItemComponent } from '../item/item.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ItemsService } from '../../services/items.service';
import { Item } from '../../interfaces/Item';

@Component({
  selector: 'app-items-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ItemComponent
  ],
  templateUrl: './items-list.component.html',
  styleUrl: './items-list.component.css'
})
export class ItemsListComponent {
  constructor(private service: ItemsService) { }

  items = this.service.items;
}
