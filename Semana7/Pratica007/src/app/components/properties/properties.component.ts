import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'app-properties',
    templateUrl: './properties.component.html',
    styleUrl: './properties.component.css'
})
export class PropertiesComponent {
    @Input() properties: any[] = [];
    @Output() propertySelected = new EventEmitter<string>();

    onSelected(property: string) {
        this.propertySelected.emit(property);
    }
}
