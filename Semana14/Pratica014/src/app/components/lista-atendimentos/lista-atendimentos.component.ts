import { Component } from '@angular/core';
import { AtendimentoService } from '../../services/atendimento.service';
import { AtendimentoViewModel } from '../../models/Atendimento/AtendimentoViewModel';

@Component({
  selector: 'app-lista-atendimentos',
  templateUrl: './lista-atendimentos.component.html',
  styleUrl: './lista-atendimentos.component.css'
})
export class ListaAtendimentosComponent {
  constructor(private service: AtendimentoService) { }

  ngOnInit() {
    this.getAll();
  }

  public atendimentos: AtendimentoViewModel[] = []

  public getAll() {
    this.service.getAll().subscribe(atendimentos => {
      this.atendimentos = atendimentos.reverse();
    });
  }
}
