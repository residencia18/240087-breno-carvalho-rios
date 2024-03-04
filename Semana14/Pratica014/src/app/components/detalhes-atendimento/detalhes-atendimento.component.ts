import { Component } from '@angular/core';
import { AtendimentoViewModel } from '../../models/Atendimento/AtendimentoViewModel';
import { AtendimentoService } from '../../services/atendimento.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalhes-atendimento',
  templateUrl: './detalhes-atendimento.component.html',
  styleUrl: './detalhes-atendimento.component.css'
})
export class DetalhesAtendimentoComponent {
  private id = this.route.snapshot.paramMap.get('id');
  public atendimento: AtendimentoViewModel = {} as AtendimentoViewModel;

  constructor(private service: AtendimentoService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getById();
  }

  public atendimentos: AtendimentoViewModel[] = []

  public getById() {
    if (!this.id) {
      return;
    }

    this.service.getById(this.id).subscribe(atendimento => {
      this.atendimento = atendimento;
    });
  }
}
