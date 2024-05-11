import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Tarefa } from '../tarefa.model';
import { Router, RouterModule } from '@angular/router';
import { tarefaStore } from '../store/tarefas.store';

@Component({
  selector: 'app-show-tarefas',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './show-tarefas.component.html',
  styleUrls: ['./show-tarefas.component.css']
})
export class ShowTarefasComponent {
  readonly tarefaStore = inject(tarefaStore);

  constructor() { }

  removeTarefa(id: string) {
    this.tarefaStore.removerTarefa(id);
  }
}
