import { Component } from '@angular/core';
import { VacinaViewModel } from '../../../models/Vacina/VacinaViewModel';
import { VacinaService } from '../../../services/vacina.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-vacinas',
  templateUrl: './lista-vacinas.component.html',
  styleUrl: './lista-vacinas.component.css'
})
export class ListaVacinasComponent {
  public vacinas: VacinaViewModel[] = [];
  constructor(private service: VacinaService, private router: Router) { }
  ngOnInit() {
    this.getAll();
  }

  public getAll() {
    this.service.getAll().subscribe(vacinas => {
      this.vacinas = vacinas.reverse();
    });
  }

  public addVacina() {
    this.router.navigate(['app/vacinas/nova']);
  }
}
