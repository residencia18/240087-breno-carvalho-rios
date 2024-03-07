import { Component } from '@angular/core';
import { SuinoService } from '../../../services/suino.service';
import { SuinoViewModel } from '../../../models/Suino/SuinoViewModel';

@Component({
  selector: 'app-lista-suinos',
  templateUrl: './lista-suinos.component.html',
  styleUrl: './lista-suinos.component.css'
})
export class ListaSuinosComponent {
  constructor(private service: SuinoService) { }

  ngOnInit() {
    this.getAll();
  }

  public suinos: SuinoViewModel[] = []

  public getAll() {
    this.service.getAll().subscribe(suinos => {
      this.suinos = suinos.reverse();
    });
  }
}
