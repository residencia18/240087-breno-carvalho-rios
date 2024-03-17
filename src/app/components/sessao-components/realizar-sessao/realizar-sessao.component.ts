import { Component } from '@angular/core';
import { SessaoViewModel } from '../../../models/Sessao/SessaoViewModel';
import { SessaoService } from '../../../services/sessao.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SessaoInputModel } from '../../../models/Sessao/SessaoInputModel';
import { Aplicacao } from '../../../models/Sessao/Aplicacao';

@Component({
  selector: 'app-realizar-sessao',
  templateUrl: './realizar-sessao.component.html',
  styleUrl: './realizar-sessao.component.css'
})
export class RealizarSessaoComponent {
  public id = this.route.snapshot.paramMap.get('id')!;
  public sessao: SessaoViewModel = {} as SessaoViewModel;
  public aplicacoes: Aplicacao[] = [];

  constructor(private service: SessaoService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getById();
  }

  public getById() {
    this.service.getById(this.id).subscribe(sessao => {
      this.sessao = sessao;
      console.log(this.sessao)
    });
  }

  public salvar() {
    const sessao: SessaoInputModel = {
      nome: this.sessao.nome,
      data: this.sessao.data,
      vacinas: this.sessao.vacinas,
      suinos: this.sessao.suinos,
      aplicacoes: this.sessao.aplicacoes as any
    };

    this.service.update(this.id, sessao).subscribe(_ => {
      this.router.navigate([`app/sessoes/detalhes/${this.id}`]);
    });
  }
}
