import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-historico-pesos',
  templateUrl: './historico-pesos.component.html',
  styleUrl: './historico-pesos.component.css'
})
export class HistoricoPesosComponent {
  @Input() options: any = {};
  @Input() data: any[] = [];

  constructor() { }
}
