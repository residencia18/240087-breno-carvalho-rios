import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AtividadeViewModel } from '../../../../models/Atividade/AtividadeViewModel';
import { AtividadeService } from '../../../../services/atividade.service';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-card-atividade',
  templateUrl: './card-atividade.component.html',
  styleUrl: './card-atividade.component.css'
})
export class CardAtividadeComponent {
  @Input() atividade: AtividadeViewModel = {} as AtividadeViewModel;
  @Output() onDelete: any = new EventEmitter();

  public contextMenuItems: MenuItem[] = [
    { label: 'Excluir', command: _ => this.delete(this.atividade.id) },
    { label: 'Editar', command: _ => this.update(this.atividade.id) }
  ]

  constructor(private service: AtividadeService, private router: Router) { }

  public delete(id: string) {
    this.service.delete(id).subscribe(_ => {
      this.onDelete.emit();
    });
  }

  public update(id: string) {
    this.router.navigate([`app/atividades/editar/${id}`]);
  }
}
