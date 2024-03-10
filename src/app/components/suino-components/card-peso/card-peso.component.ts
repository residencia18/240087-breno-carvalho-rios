import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { PesoService } from '../../../services/peso.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PesoViewModel } from '../../../models/Peso/PesoViewModel';

@Component({
  selector: 'app-card-peso',
  templateUrl: './card-peso.component.html',
  styleUrl: './card-peso.component.css'
})
export class CardPesoComponent {

  public id = this.route.snapshot.paramMap.get('id');
  @Input() suino: PesoViewModel = {} as PesoViewModel;
  @Output() onDelete: any = new EventEmitter();

  constructor(private pesosService: PesoService, private route: ActivatedRoute, private router: Router) { }

  public contextMenuItems: MenuItem[] = [
    { label: 'Excluir', command: _ => this.deletePeso(this.suino.id) },
    { label: 'Editar', command: _ => this.update(this.suino.id) },
  ]

  public deletePeso(id: string) {
    this.pesosService.delete(id, this.id!).subscribe(() => {
      window.location.reload();
    });
  }

  public update(id: string) {
    this.router.navigate([`/pesos/editar/${this.id}/${id}`]);
  }
}
