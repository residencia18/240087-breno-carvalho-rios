import { Component, EventEmitter, Input, Output } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';

@Component({
    selector: 'app-properties',
    templateUrl: './properties.component.html',
    styleUrl: './properties.component.css'
})
export class PropertiesComponent {
    public vehicleProperties: any[] = [];

    constructor(private vehiclesService: VehiclesService) {
        this.vehiclesService.selectedVehicle$.subscribe(vehicleProperties => {
            this.vehicleProperties = vehicleProperties.slice(0, -1);
        });
    }

    onPropertySelected(property: any) {
        this.vehiclesService.selectProperty(property);
    }
}
