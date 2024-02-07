import { Component, ViewChild } from '@angular/core';
import { FormArray, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Exercicio01';
  public formulario: FormGroup;
  public statusOptions = [
    { label: 'Não Instalada', value: 'nao-instalada' },
    { label: 'Instalada', value: 'instalada' },
    { label: 'Operante', value: 'operante' }
  ]
  public sent = false;

  constructor() {
    this.formulario = new FormGroup({
      'nome': new FormControl(null, Validators.required),
      'email': new FormControl(null, [Validators.required, Validators.email,]),
      'localizacao': new FormControl(null, [Validators.required]),
      'status': new FormControl(null, [Validators.required])
    });

    this.formulario.valueChanges.subscribe(() => {
      this.sent = false;
    })
  }

  onSubmit() {
    if (!this.formulario.valid) {
      return;
    }
    this.sent = true;
  }

  changeStatus(status: string){
    this.formulario.get('status')?.setValue(status);
  }
}
