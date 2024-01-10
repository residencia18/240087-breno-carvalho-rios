import { Component, EventEmitter, Input, Output } from '@angular/core'

@Component({
  selector: 'app-lista-tarefas',
  templateUrl: './lista-tarefas.component.html',
  styleUrl: './lista-tarefas.component.css'
})
export class ListaTarefasComponent {
  @Input() listaTarefas: string[] = [];
  @Output() tarefaAdicionada = new EventEmitter<string>();
  @Output() tarefaRemovida = new EventEmitter<number>();

  removerTarefa(numero: number) {
    this.tarefaRemovida.emit(numero);
  }

  inserirTarefa(tarefa: string) {
    this.tarefaAdicionada.emit(tarefa);
  }
}
