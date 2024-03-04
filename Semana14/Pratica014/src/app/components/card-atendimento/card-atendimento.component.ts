import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AtendimentoViewModel } from '../../models/Atendimento/AtendimentoViewModel';
import { AtendimentoService } from '../../services/atendimento.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-card-atendimento',
  templateUrl: './card-atendimento.component.html',
  styleUrl: './card-atendimento.component.css'
})
export class CardAtendimentoComponent {
  @Input() atendimento: AtendimentoViewModel = {} as AtendimentoViewModel;
  @Output() onDelete: any = new EventEmitter();

  constructor(private service: AtendimentoService, private router: Router) { }

  public delete(id: string) {
    this.service.delete(id).subscribe(_ => {
      this.onDelete.emit();
    });
  }

  public update(id: string) {
    this.router.navigate([`/atendimentos/editar/${id}`]);
  }

  public detalhes(id: string) {
    this.router.navigate([`/atendimentos/detalhes/${id}`]);
  }
}
