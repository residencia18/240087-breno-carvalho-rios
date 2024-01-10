import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-item-tarefas',
  templateUrl: './item-tarefas.component.html',
  styleUrl: './item-tarefas.component.css'
})
export class ItemTarefasComponent {
  @Input() itemTarefa: string = '';
  @Input() itemNumero: number = 0;
  @Output() tarefaRemovida = new EventEmitter<number>();

  removerTarefa(numero: number) {
    this.tarefaRemovida.emit(numero);
  }
}
