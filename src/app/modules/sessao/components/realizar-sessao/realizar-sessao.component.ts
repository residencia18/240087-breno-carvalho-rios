import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SessaoViewModel } from '../../../../models/Sessao/SessaoViewModel';
import { Realizacao } from '../../../../models/Sessao/Realizacao';
import { SessaoService } from '../../../../services/sessao.service';
import { SessaoInputModel } from '../../../../models/Sessao/SessaoInputModel';


@Component({
  selector: 'app-realizar-sessao',
  templateUrl: './realizar-sessao.component.html',
  styleUrl: './realizar-sessao.component.css'
})
export class RealizarSessaoComponent {
  public id = this.route.snapshot.paramMap.get('id')!;
  public sessao: SessaoViewModel = {} as SessaoViewModel;
  public realizacoes: Realizacao[] = [];

  constructor(private service: SessaoService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getById();
  }

  public getById() {
    this.service.getById(this.id).subscribe(sessao => {
      this.sessao = sessao;
    });
  }

  public salvar() {
    const sessao: SessaoInputModel = {
      nome: this.sessao.nome,
      data: this.sessao.data,
      atividades: this.sessao.atividades,
      suinos: this.sessao.suinos,
      realizacoes: this.sessao.realizacoes as any
    };

    this.service.update(this.id, sessao).subscribe(_ => {
      this.router.navigate([`app/sessoes/detalhes/${this.id}`]);
    });
  }

  public statusChange(atividade: any){
    atividade.updatedAt = new Date().toISOString();
  }
}
