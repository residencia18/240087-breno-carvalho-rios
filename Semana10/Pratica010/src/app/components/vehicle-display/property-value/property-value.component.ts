import { Component, Input } from '@angular/core';
import { VehiclesService } from '../../../services/vehicles.service';

@Component({
    selector: 'app-property-value',
    templateUrl: './property-value.component.html',
    styleUrl: './property-value.component.css'
})
export class PropertyValueComponent {
    @Input() property: any = {};
    private selectedProperty: any = {};

    constructor(private vehiclesService: VehiclesService) {
        this.vehiclesService.selectedProperty$.subscribe(property => {
            this.selectedProperty = property;
        });
    }

    isSelected() {
        return this.selectedProperty.label === this.property.label;
    }
}
