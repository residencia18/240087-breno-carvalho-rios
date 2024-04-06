import { Component, ElementRef, ViewChild } from '@angular/core';
import { SuinoService } from '../../../services/suino.service';
import { SuinoViewModel } from '../../../models/Suino/SuinoViewModel';
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-lista-suinos',
  templateUrl: './lista-suinos.component.html',
  styleUrl: './lista-suinos.component.css',
  animations: [
    trigger(
      'inOutAnimation',
      [
        transition(':enter', [
          style({ transform: 'translateY(-100%)', opacity: 0 }),
          animate('150ms', style({ transform: 'translateY(0)', opacity: 1 }))
        ]),
        transition(':leave', [
          style({ transform: 'translateY(0)', opacity: 1 }),
          animate('150ms', style({ transform: 'translateY(-100%)', opacity: 0 }))
        ])
      ]
    )
  ]
})
export class ListaSuinosComponent {
  private _suinos: SuinoViewModel[] = [];

  public suinos: SuinoViewModel[] = []
  public filtersIsVisible = false;
  public filterValue = "";

  public filterOptions = [
    { label: "Brinco do Pai", value: "BP" },
    { label: "Brinco da Mãe", value: "BM" },
    { label: "Data de Nascimento", value: "DN" },
    { label: "Data da Saída", value: "DS" },
    { label: "Sexo", value: "SX" },
    { label: "Status", value: "ST" },
  ]
  public filter = this.filterOptions.at(0)?.value;

  public sexoOptions = [
    { label: "M" },
    { label: "F" },
  ]
  public statusOptions = [
    { label: "Ativo" },
    { label: "Vendido" },
    { label: "Morto" },
  ]
  constructor(private service: SuinoService) { }

  ngOnInit() {
    this.getAll();
  }

  public getAll() {
    this.service.getAll().subscribe(suinos => {
      this._suinos = suinos.reverse();
      this.suinos = this._suinos;
    });
  }

  public getSuinos() {
    return this._suinos;
  }

  public toggleFilter() {
    this.filtersIsVisible = !this.filtersIsVisible;
    if (!this.filtersIsVisible) {
      this.clearFilters();
    }
  }

  public filterSuinos() {
    console.log(this.filterValue);
    switch (this.filter) {
      case "BP":
        this.suinos = this._suinos.filter(suino => suino.brincoPai == parseInt(this.filterValue));
        break;
      case "BM":
        this.suinos = this._suinos.filter(suino => suino.brincoMae == parseInt(this.filterValue));
        break;
      case "DN":
        this.suinos = this._suinos.filter(suino => suino.dataNascimento.toString() == new Date(this.filterValue).toISOString());
        break;
      case "DS":
        this.suinos = this._suinos.filter(suino => suino.dataSaida.toString() == new Date(this.filterValue).toISOString());
        break;
      case "SX":
        this.suinos = this._suinos.filter(suino => suino.sexo == this.filterValue);
        break;
      case "ST":
        this.suinos = this._suinos.filter(suino => suino.status == this.filterValue);
        break;
      default:
        break;
    }
  }

  public clearFilters() {
    this.suinos = this._suinos;
  }
}
