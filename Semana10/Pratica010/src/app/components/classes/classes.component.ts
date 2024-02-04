import { Component } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';

@Component({
    selector: 'app-classes',
    templateUrl: './classes.component.html',
    styleUrl: './classes.component.css'
})
export class ClassesComponent {
    public vehicles: any[] = [];

    constructor(private vehiclesService: VehiclesService) {
        this.vehiclesService.selectedCategory$.subscribe(vehicles => {
            this.vehicles = vehicles;
        });
    }

    onVehicleSelected(vehicle: any) {
        this.vehiclesService.selectVehicle(vehicle);
    }
}
