import { Component } from '@angular/core';
import { TarefaState } from '../store/tarefa.reducer';
import { Store } from '@ngrx/store';
import { atualizarTarefa } from '../store/tarefa.actions';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Observable, firstValueFrom } from 'rxjs';
import { selectorSelecionaTarefa } from '../store/tarefa.seletors';
import { Tarefa } from '../tarefa.model';

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
  private id = this.route.snapshot.paramMap.get("id")!;
  descricao = '';
  tasks$!: Observable<TarefaState>;

  constructor(private store: Store<{ tarefas: TarefaState }>, private route: ActivatedRoute) { }

  async ngOnInit() {
    let _tasks = await firstValueFrom(this.store.select(selectorSelecionaTarefa));
    this.descricao = _tasks.tarefas.find((t) => t.id === this.id)!.descricao;
    let _params = await firstValueFrom(this.route.params);
    this.id = _params['id'];
  }

  async updateTask() {
    let task = {
      id: this.id,
      descricao: this.descricao
    }
    this.store.dispatch(atualizarTarefa({ task }));
  }
}
