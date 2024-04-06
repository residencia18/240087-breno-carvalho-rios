import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { SessaoViewModel } from '../../../models/Sessao/SessaoViewModel';
import { SessaoService } from '../../../services/sessao.service';

@Component({
  selector: 'app-card-sessao',
  templateUrl: './card-sessao.component.html',
  styleUrl: './card-sessao.component.css'
})
export class CardSessaoComponent {
  @Input() sessao: SessaoViewModel = {} as SessaoViewModel;
  @Output() onDelete: any = new EventEmitter();

  constructor(private service: SessaoService, private router: Router) { }

  public contextMenuItems: MenuItem[] = [
    { label: 'Excluir', command: _ => this.delete(this.sessao.id) },
    { label: 'Editar', command: _ => this.update(this.sessao.id) },
    { label: 'Realizar Sessão', command: _ => this.realizar(this.sessao.id) },
    { label: 'Ver Detalhes', command: _ => this.view(this.sessao.id) },
  ]

  public delete(id: string) {
    this.service.delete(id).subscribe(_ => {
      this.onDelete.emit();
    });
  }

  public update(id: string) {
    this.router.navigate([`app/sessoes/editar/${id}`]);
  }

  public view(id: string) {
    this.router.navigate([`app/sessoes/detalhes/${id}`]);
  }

  public realizar(id: string) {
    this.router.navigate([`app/sessoes/realizar/${id}`]);
  }
}
