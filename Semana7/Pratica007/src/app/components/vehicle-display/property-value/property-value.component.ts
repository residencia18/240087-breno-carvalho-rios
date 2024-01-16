import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-property-value',
    templateUrl: './property-value.component.html',
    styleUrl: './property-value.component.css'
})
export class PropertyValueComponent {
    @Input() currentProperty: string = '';
    @Input() label: string = '';
    @Input() value: string = '';

    isSelected() {
        return this.currentProperty == this.label;
    }
}
