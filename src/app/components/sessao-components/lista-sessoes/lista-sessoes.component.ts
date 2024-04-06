import { Component } from '@angular/core';
import { animate, style, transition, trigger } from '@angular/animations';
import { SessaoService } from '../../../services/sessao.service';
import { SessaoViewModel } from '../../../models/Sessao/SessaoViewModel';

@Component({
  selector: 'app-lista-sessoes',
  templateUrl: './lista-sessoes.component.html',
  styleUrl: './lista-sessoes.component.css',
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
export class ListaSessoesComponent {
  private _sessoes: SessaoViewModel[] = [];

  public sessoes: SessaoViewModel[] = []
  public filtersIsVisible = false;
  public filterValue = "";

  public filterOptions = [
    { label: "Data da Sessão", value: "DS" }
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
  constructor(private service: SessaoService) { }

  ngOnInit() {
    this.getAll();
  }

  public getAll() {
    this.service.getAll().subscribe(sessoes => {
      this._sessoes = sessoes.reverse();
      this.sessoes = this._sessoes;
    });
  }

  public getsessoes() {
    return this._sessoes;
  }

  public toggleFilter() {
    this.filtersIsVisible = !this.filtersIsVisible;
    if (!this.filtersIsVisible) {
      this.clearFilters();
    }
  }

  public filtersessoes() {
    console.log(this.filterValue);
    switch (this.filter) {
      case "DS":
        this.sessoes = this._sessoes.filter(sessao => sessao.data.toString() == new Date(this.filterValue).toISOString());
        break;
      default:
        break;
    }
  }

  public clearFilters() {
    this.sessoes = this._sessoes;
  }
}
