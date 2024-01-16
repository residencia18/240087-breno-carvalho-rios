import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'app-objects',
    templateUrl: './objects.component.html',
    styleUrl: './objects.component.css'
})

export class ObjectsComponent {
    @Input() categories: string[] = [];
    @Output() categorySelected = new EventEmitter<any>();

    onSelect(category: string) {
        this.categorySelected.emit(category);
    }
}
