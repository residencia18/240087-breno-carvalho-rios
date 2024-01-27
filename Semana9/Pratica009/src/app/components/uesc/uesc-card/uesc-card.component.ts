import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-uesc-card',
  templateUrl: './uesc-card.component.html',
  styleUrl: './uesc-card.component.css'
})
export class UescCardComponent {
  @Input() title = "";
}
