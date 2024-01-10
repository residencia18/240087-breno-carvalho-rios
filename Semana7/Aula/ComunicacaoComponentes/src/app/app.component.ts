import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ComunicacaoComponentes';

  tarefasApp: string[] = ['Tarefa 1', 'Tarefa 2', 'Tarefa 3', 'Tarefa 4'];
  
  nomeTarefa: string = '';
  inserirTarefa(){
    this.tarefasApp.push(this.nomeTarefa);
  }
}
