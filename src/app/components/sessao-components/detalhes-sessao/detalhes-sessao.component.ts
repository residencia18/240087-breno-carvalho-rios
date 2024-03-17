import { Component } from '@angular/core';
import { SessaoService } from '../../../services/sessao.service';
import { ActivatedRoute } from '@angular/router';
import { SessaoViewModel } from '../../../models/Sessao/SessaoViewModel';

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

  public getVacinasCount() {
    if (!this.sessao.vacinas) {
      return 0;
    }
    return this.sessao.vacinas.length;
  }

  public getById() {
    this.service.getById(this.id).subscribe(sessao => {
      this.sessao = sessao;
    });
  }
}
