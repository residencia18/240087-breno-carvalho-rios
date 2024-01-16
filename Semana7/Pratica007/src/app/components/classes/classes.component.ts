import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'app-classes',
    templateUrl: './classes.component.html',
    styleUrl: './classes.component.css'
})
export class ClassesComponent {
    @Input() vehicles: any[] = [];
    @Output() vehicleSelected = new EventEmitter<any>();

    onSelect(vehicle: any) {
        this.vehicleSelected.emit(vehicle);
    }
}
