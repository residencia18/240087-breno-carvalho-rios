import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-item-tarefas',
  templateUrl: './item-tarefas.component.html',
  styleUrl: './item-tarefas.component.css'
})
export class ItemTarefasComponent {
  @Input() itemTarefa: string = '';
  @Input() itemIndice: number = 0;
  @Output() tarefaRemovida = new EventEmitter<number>();

  removerTarefa(indice: number) {
    this.tarefaRemovida.emit(indice);
  }
}
