import { Component } from '@angular/core';
import { Carro } from '../../types/carro';
import { BancoServiceService } from '../../services/banco-service.service';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrl: './listar.component.css'
})
export class ListarComponent {
  carros: Carro[] = [];
  carro: any = {};

  constructor(private bancoService: BancoServiceService) {
    this.bancoService.carros$.subscribe(carros => {
      this.carros = carros;
    });
  }

  ngOnInit() {
    this.bancoService.getCarros()
  }

  getProperties(carro: Carro) {
    return Object.values(carro);
  }

  selectCarro(carro: Carro){
    this.carro = carro;
  }
}
