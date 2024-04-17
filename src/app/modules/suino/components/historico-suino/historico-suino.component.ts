import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';
import { SuinoService } from '../../../../services/suino.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { PesoService } from '../../../../services/peso.service';
import { firstValueFrom } from 'rxjs';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-historico-suino',
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
    RouterLink,
  ],
  templateUrl: './historico-suino.component.html',
  styleUrl: './historico-suino.component.css'
})
export class HistoricoSuinoComponent {
  public readonly id = this.route.snapshot.paramMap.get('id');
  public suino: any = {};
  public historico: any[] = [];

  constructor(private service: SuinoService, private pesoService: PesoService, private route: ActivatedRoute, private router: Router) {
    if (!this.id) {
      this.router.navigate(['app/suinos']);
    };
  }

  async ngOnInit() {
    this.suino = await firstValueFrom(this.service.getById(this.id!));
    let atividades = (await firstValueFrom(this.service.getAtividadesByBrinco(this.suino.brinco))).map(atividade => {
      return { data: atividade.updatedAt, descricao: atividade.nome, detalhes: atividade.realizada ? 'Realizada' : 'Não Realizada' }
    });
    let pesos = (await firstValueFrom(this.pesoService.getAll(this.id!))).map(pesagem => {
      return { data: pesagem.data, descricao: 'Pesagem', detalhes: `${pesagem.peso} Kg` }
    });
    this.historico = atividades.concat(pesos).sort((a, b) => new Date(a.data).getTime() - new Date(b.data).getTime()).reverse();
  }
}
