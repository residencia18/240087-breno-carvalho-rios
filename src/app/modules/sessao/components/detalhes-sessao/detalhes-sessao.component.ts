import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SessaoViewModel } from '../../../../models/Sessao/SessaoViewModel';
import { SessaoService } from '../../../../services/sessao.service';

@Component({
  selector: 'app-detalhes-sessao',
  templateUrl: './detalhes-sessao.component.html',
  styleUrl: './detalhes-sessao.component.css'
})
export class DetalhesSessaoComponent {
  public id = this.route.snapshot.paramMap.get('id')!;
  public sessao: SessaoViewModel = {} as SessaoViewModel;

  constructor(private service: SessaoService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getById();
  }

  public getSuinosCount() {
    if (!this.sessao.suinos) {
      return 0;
    }
    return this.sessao.suinos.length;
  }

  public getAtividadesCount() {
    if (!this.sessao.atividades) {
      return 0;
    }
    return this.sessao.atividades.length;
  }

  public getById() {
    this.service.getById(this.id).subscribe(sessao => {
      this.sessao = sessao;
    });
  }
}
