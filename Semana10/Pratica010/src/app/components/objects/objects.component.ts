import { Component } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';

@Component({
    selector: 'app-objects',
    templateUrl: './objects.component.html',
    styleUrl: './objects.component.css'
})

export class ObjectsComponent {
    public categories: string[] = ["Selecione uma categoria"];

    constructor(private vehiclesService: VehiclesService) {
        this.vehiclesService.vehiclesList$.subscribe(vehicles => {
            this.categories.push(...Object.keys(vehicles));
        });
        this.vehiclesService.getVehiclesList();
    }

    onCategorySelected(category: string) {
        this.vehiclesService.selectCategory(category);
    }
}
