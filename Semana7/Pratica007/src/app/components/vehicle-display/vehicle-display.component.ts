import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-vehicle-display',
    templateUrl: './vehicle-display.component.html',
    styleUrl: './vehicle-display.component.css'
})
export class VehicleDisplayComponent {
    @Input() vehicle: any = {};
    @Input() properties: any[] = [];
    @Input() currentProperty = '';
}
