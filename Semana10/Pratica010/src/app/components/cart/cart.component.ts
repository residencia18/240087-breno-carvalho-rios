import { Component, Input } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html',
    styleUrl: './cart.component.css'
})
export class CartComponent {
    public cartItems: any[] = [];
    constructor(vehiclesService: VehiclesService) {
        vehiclesService.cartItems$.subscribe(cartItems => {
            this.cartItems.push(cartItems);
        });
    }
}
