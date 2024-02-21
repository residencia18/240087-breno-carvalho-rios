import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BancoServiceService } from '../../services/banco-service.service';
import { Carro } from '../../types/carro';

@Component({
  selector: 'app-form-adicionar',
  templateUrl: './form-adicionar.component.html',
  styleUrl: './form-adicionar.component.css'
})

export class FormAdicionarComponent {  
  formAdicionar: FormGroup = new FormGroup({
    "modelo": new FormControl(null, []),
    "marca": new FormControl(null, []),
    "ano": new FormControl(null, []),
    "cor": new FormControl(null, []),
    "valor": new FormControl(null, []),
    "foto": new FormControl(null, []),
  });

  constructor(private bancoService: BancoServiceService){}

  onSubmit(){
    let carro: Carro = {
      modelo: this.formAdicionar.get("modelo")?.value || "Não Definido",
      marca: this.formAdicionar.get("marca")?.value  || "Não Definido",
      ano: parseInt(this.formAdicionar.get("ano")?.value)  || 0,
      cor: this.formAdicionar.get("cor")?.value  || "Não Definido",
      valor: parseFloat(this.formAdicionar.get("valor")?.value)  || 0,
      foto: this.formAdicionar.get("foto")?.value  || "Não Definido",
    }
    this.bancoService.addCarro(carro);
  }
}
