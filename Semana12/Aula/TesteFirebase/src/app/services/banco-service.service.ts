import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Carro } from '../types/carro';

@Injectable({
  providedIn: 'root'
})

export class BancoServiceService {
  private _carros = new Subject<Carro[]>();
  public carros$ = this._carros.asObservable();

  private carros: Carro[] = [
    {
      modelo: "Modelo 1",
      marca: "Marca 1",
      ano: 1,
      cor: "Cor 1",
      valor: 1,
      foto: "Foto 1" 
    },
    {
      modelo: "Modelo 2",
      marca: "Marca 2",
      ano: 2,
      cor: "Cor 2",
      valor: 2,
      foto: "Foto 2" 
    },
    {
      modelo: "Modelo 3",
      marca: "Marca 3",
      ano: 3,
      cor: "Cor 3",
      valor: 3,
      foto: "Foto 3" 
    }
  ]

  constructor() {
    this._carros.next(this.carros);
  }
  
  getCarros(){
    this._carros.next(this.carros);
  }

  addCarro(carro: Carro){
    this.carros.push(carro);
    this._carros.next(this.carros);
  }
}
