import { Component, EventEmitter, Input, Output } from '@angular/core';
import { VacinaViewModel } from '../../../models/Vacina/VacinaViewModel';
import { VacinaService } from '../../../services/vacina.service';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-card-vacina',
  templateUrl: './card-vacina.component.html',
  styleUrl: './card-vacina.component.css'
})
export class CardVacinaComponent {
  @Input() vacina: VacinaViewModel = {} as VacinaViewModel;
  @Output() onDelete: any = new EventEmitter();

  public contextMenuItems: MenuItem[] = [
    { label: 'Excluir', command: _ => this.delete(this.vacina.id) },
    { label: 'Editar', command: _ => this.update(this.vacina.id) }
  ]

  constructor(private service: VacinaService, private router: Router) { }

  public delete(id: string) {
    this.service.delete(id).subscribe(_ => {
      this.onDelete.emit();
    });
  }

  public update(id: string) {
    this.router.navigate([`app/vacinas/editar/${id}`]);
  }
}
