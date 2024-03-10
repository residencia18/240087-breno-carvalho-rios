import { Component } from '@angular/core';
import { SuinoViewModel } from '../../../models/Suino/SuinoViewModel';
import { SuinoService } from '../../../services/suino.service';
import { ActivatedRoute } from '@angular/router';
import { PesoService } from '../../../services/peso.service';
import { PesoViewModel } from '../../../models/Peso/PesoViewModel';

@Component({
  selector: 'app-detalhes-suino',
  templateUrl: './detalhes-suino.component.html',
  styleUrl: './detalhes-suino.component.css'
})
export class DetalhesSuinoComponent {

  private id = this.route.snapshot.paramMap.get('id');
  public suino: SuinoViewModel = {} as SuinoViewModel;
  public pesos: PesoViewModel[] = [];

  public chartData: any = {};

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

  constructor(private service: SuinoService, private pesosService: PesoService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getById();
    this.getPesosBySuinoId();
  }

  public suinos: SuinoViewModel[] = []

  public getById() {
    if (!this.id) {
      return;
    }

    this.service.getById(this.id).subscribe(suino => {
      this.suino = suino;
    });
  }

  public getPesosBySuinoId() {
    if (!this.id) {
      return;
    }

    this.pesosService.getAll(this.id).subscribe(pesos => {
      this.pesos = pesos;
      this.chartData = this.createChartData();
    });
  }

  public createChartData() {
    const labels = this.pesos.map(peso => peso.data.toString().slice(0, 10).split('-').reverse().join('/'));
    const data = this.pesos.map(peso => peso.peso);
    return { labels, datasets: [{ label: "Peso", data }] };
  }

  public calculateAge(dataNascimento: Date): number {
    return this.service.calculateAge(dataNascimento);
  }
}
