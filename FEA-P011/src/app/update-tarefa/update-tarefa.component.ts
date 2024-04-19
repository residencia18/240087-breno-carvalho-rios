import { Component } from '@angular/core';
import { TarefaState } from '../store/tarefa.reducer';
import { Store } from '@ngrx/store';
import { atualizarTarefa } from '../store/tarefa.actions';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { selectorSelecionaTarefa } from '../store/tarefa.seletors';

@Component({
  selector: 'app-update-tarefa',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  templateUrl: './update-tarefa.component.html',
  styleUrls: ['./update-tarefa.component.css']
})
export class UpdateTarefaComponent {
  private readonly id = this.route.snapshot.paramMap.get("id")!;
  descricao = '';
  tasks$!: Observable<TarefaState>;

  constructor(private store: Store<{ tarefas: TarefaState }>, private route: ActivatedRoute) {
    this.tasks$ = this.store.select(selectorSelecionaTarefa);
    this.tasks$.subscribe((t) => {
      this.descricao = t.tarefas.find((t) => t.id === this.id)!.descricao;
    });
  }

  updateTask() {
    let descricao = this.descricao as string;
    this.store.dispatch(atualizarTarefa({ id: this.id, descricao }));
  }
}
