import { Component } from '@angular/core';

@Component({
  selector: 'app-historico-atividades',
  standalone: true,
  imports: [],
  templateUrl: './historico-atividades.component.html',
  styleUrl: './historico-atividades.component.css'
})
export class HistoricoAtividadesComponent {

  public chartOptions = {
    title: {
      display: true,
      text: 'Article Views',
      fontSize: 32,
      position: 'top',
    },
    scales: {
      x: {
        ticks: {
          color: '#495057',
        },
        grid: {
          color: '#ebedef',
        },
      },
      y: {
        ticks: {
          color: '#495057',
        },
        grid: {
          color: '#ebedef',
        },
      },
    },
  };
}
