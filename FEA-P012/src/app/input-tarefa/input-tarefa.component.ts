import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Tarefa } from '../tarefa.model';
import { tarefaStore } from '../store/tarefas.store';

@Component({
  selector: 'app-input-tarefa',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './input-tarefa.component.html',
  styleUrls: ['./input-tarefa.component.css']
})
export class InputTarefaComponent {
  newTask = '';
  private readonly tarefaStore = inject(tarefaStore);
  constructor() { }

  addTask() {
    const newTarefa: Tarefa = {
      id: this.generateId(),
      descricao: this.newTask,
    };

    this.tarefaStore.adicionarTarefa(newTarefa);

  }

  generateId() {
    return Date.now().toString(36) + Math.random().toString(36).substring(2);
  }
}
