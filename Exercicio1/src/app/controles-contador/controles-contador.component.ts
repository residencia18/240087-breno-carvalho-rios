import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { incrementar, decrementar, duplicar } from "../store/contador.actions";

@Component({
  selector: 'app-controles-contador',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './controles-contador.component.html',
  styleUrls: ['./controles-contador.component.css']
})
export class ControlesContadorComponent {
  constructor(private store:Store) { 
  }
  incrementar() {
    this.store.dispatch(incrementar({valor: 10}));
  }
  decrementar(){
    this.store.dispatch(decrementar({valor: 10}));
  }
  duplicar(){
    this.store.dispatch(duplicar());
  }
}



//alternativa de escrita da action
    //this.store.dispatch(new IncrementarAction(10));
