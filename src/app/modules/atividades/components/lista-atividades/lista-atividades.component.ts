import { Component } from '@angular/core';
import { AtividadeViewModel } from '../../../../models/Atividade/AtividadeViewModel';
import { AtividadeService } from '../../../../services/atividade.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-atividades',
  templateUrl: './lista-atividades.component.html',
  styleUrl: './lista-atividades.component.css'
})
export class ListaAtividadesComponent {
  public atividades: AtividadeViewModel[] = [];
  constructor(private service: AtividadeService, private router: Router) { }
  ngOnInit() {
    this.getAll();
  }

  public getAll() {
    this.service.getAll().subscribe(atividades => {
      this.atividades = atividades.reverse();
    });
  }

  public addAtividade() {
    this.router.navigate(['app/atividades/nova']);
  }
}
