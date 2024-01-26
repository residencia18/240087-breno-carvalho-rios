import { Component, Input } from '@angular/core';
import { destination } from '../types/turismo.types';

@Component({
  selector: 'app-turismo-card',
  templateUrl: './turismo-card.component.html',
  styleUrl: './turismo-card.component.css'
})

export class TurismoCardComponent {
  @Input() destination: destination = {} as destination;
}
