import { Component } from '@angular/core';
import { SuinoService } from '../../../../services/suino.service';
import { PesoService } from '../../../../services/peso.service';
import { ActivatedRoute, Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { ChartModule } from 'primeng/chart';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-historico-atividades',
  standalone: true,
  imports: [
    CommonModule,
    ChartModule
  ],
  templateUrl: './historico-atividades.component.html',
  styleUrl: './historico-atividades.component.css'
})
export class HistoricoAtividadesComponent {
  public readonly id = this.route.snapshot.paramMap.get('id');
  public suino: any = {};
  public historico: any[] = [];
  public pesos: any[] = [];
  public atividades: any[] = [];
  public chartData: any = {};

  constructor(private service: SuinoService, private pesoService: PesoService, private route: ActivatedRoute, private router: Router) {
    if (!this.id) {
      this.router.navigate(['app/suinos']);
    };
  }

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

  async ngOnInit() {
    this.suino = await firstValueFrom(this.service.getById(this.id!));
    let atividades = (await firstValueFrom(this.service.getAtividadesByBrinco(this.suino.brinco))).map(atividade => {
      return { data: atividade.updatedAt, descricao: atividade.nome, detalhes: atividade.realizada ? 'Realizada' : 'Não Realizada' }
    });
    let pesos = (await firstValueFrom(this.pesoService.getAll(this.id!))).map(pesagem => {
      return { data: pesagem.data, descricao: 'Pesagem', detalhes: `${pesagem.peso} Kg` }
    });
    this.historico = atividades.concat(pesos).sort((a, b) => new Date(a.data).getTime() - new Date(b.data).getTime()).reverse();
    this.chartData = this.createChartData();
  }

  public createChartData() {
    const data = this.contarAtividades(this.historico);
    return { labels: Object.keys(data), datasets: [{ label: 'Atividades', data: Object.values(data) }] };
  }

  public contarAtividades(atividades: any[]): { [descricao: string]: number } {
    const contagem: { [descricao: string]: number } = {};

    for (const atividade of atividades) {
      if (contagem[atividade.descricao]) {
        contagem[atividade.descricao]++;
      } else {
        contagem[atividade.descricao] = 1;
      }
    }

    return contagem;
  }

}