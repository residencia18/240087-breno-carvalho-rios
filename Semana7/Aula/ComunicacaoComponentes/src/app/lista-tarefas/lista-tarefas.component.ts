import { Component, Input } from '@angular/core'

@Component({
  selector: 'app-lista-tarefas',
  templateUrl: './lista-tarefas.component.html',
  styleUrl: './lista-tarefas.component.css'
})
export class ListaTarefasComponent {
  @Input() listaTarefas: string[] = [];
}
