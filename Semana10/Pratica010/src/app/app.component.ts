import { Component } from '@angular/core';
import * as data from '../assets/data/vehicles.json';
import { VehiclesService } from './services/vehicles.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent {
    title = 'Pratica010';

    constructor(private vehiclesService: VehiclesService) { }

    addToCart() {
        this.vehiclesService.addToCart();
    }
}
