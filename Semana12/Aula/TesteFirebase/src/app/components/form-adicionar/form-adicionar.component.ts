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
    "modelo": new FormControl(null, [Validators.required]),
    "marca": new FormControl(null, [Validators.required]),
    "ano": new FormControl(null, [Validators.required]),
    "cor": new FormControl(null, [Validators.required]),
    "valor": new FormControl(null, [Validators.required]),
    "foto": new FormControl(null, [Validators.required]),
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
