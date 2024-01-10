import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-item-tarefas',
  templateUrl: './item-tarefas.component.html',
  styleUrl: './item-tarefas.component.css'
})
export class ItemTarefasComponent {
  @Input() itemTarefa: string = '';
}
