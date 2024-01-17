import { Component } from '@angular/core';
import * as data from '../assets/data/vehicles.json';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent {
    title = 'Pratica007';

    vehiclesData = data;
    categories = Object.keys(data).slice(0, -1);
    vehicles: any[] = [];
    vehicle: any = {};
    properties: any[] = [];
    currentProperty = '';
    cartItems: any[] = [];

    ngOnInit() {
        this.onCategorySelected(this.categories[0]);
        this.onVehicleSelected(this.vehicles[0]);
        this.onPropertySelected(this.properties[0]);
    }

    onCategorySelected(category: string) {
        this.vehicles = this.vehiclesData[category as keyof typeof this.vehiclesData] as typeof this.vehicles;
    }

    onVehicleSelected(vehicle: any) {
        this.vehicle = vehicle;
        this.properties = Object.keys(vehicle).slice(0, -1);
    }

    onPropertySelected(property: string) {
        this.currentProperty = property;
    }

    addToCart() {
        this.cartItems.push(this.vehicle);
    }
}
