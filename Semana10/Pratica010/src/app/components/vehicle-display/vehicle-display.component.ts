import { Component, Input } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';

@Component({
    selector: 'app-vehicle-display',
    templateUrl: './vehicle-display.component.html',
    styleUrl: './vehicle-display.component.css'
})
export class VehicleDisplayComponent {
    public vehicleProperties: any[] = [];
    constructor(private vehiclesService: VehiclesService) {
        this.vehiclesService.selectedVehicle$.subscribe(properties => {
            this.vehicleProperties = properties;
        });
    }

    getProperties() {
        return this.vehicleProperties.slice(0, -1);
    }

    getImage() {
        const _image = this.vehicleProperties.find((property) => property.label == 'Image');

        if (_image) {
            return _image.value;
        }

        return 'https://placehold.co/300x200';
    }

    onPropertySelected(property: any) {
        this.vehiclesService.selectProperty(property);
    }
}
