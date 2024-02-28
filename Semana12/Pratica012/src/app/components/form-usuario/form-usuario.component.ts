import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { FormLogService } from '../../services/form-log.service';

@Component({
  selector: 'app-form-usuario',
  templateUrl: './form-usuario.component.html',
  styleUrl: './form-usuario.component.css'
})
export class FormUsuarioComponent {
  public formLog: any[] = [];

  public genderOptions = [
    { label: 'Masculino', value: 'M' },
    { label: 'Feminino', value: 'F' },
    { label: 'Outro', value: 'O' }
  ]

  public professionOptions = [
    { label: 'Engenheiro(a)', value: 'engenheiro' },
    { label: 'Médico(a)', value: 'medico' },
    { label: 'Professor(a)', value: 'professor' },
    { label: 'Advogado(a)', value: 'advogado' },
    { label: 'Arquiteto(a)', value: 'arquiteto' },
    { label: 'Enfermeiro(a)', value: 'enfermeiro' },
    { label: 'Dentista', value: 'dentista' },
    { label: 'Farmacêutico(a)', value: 'farmaceutico' },
    { label: 'Psicólogo(a)', value: 'psicologo' },
    { label: 'Contador(a)', value: 'contador' }
  ]

  constructor(private formLogService: FormLogService) {
    this.formLogService.formLog$.subscribe(formLog => this.formLog.push(formLog));

    this.initializeLogs('username');
    this.initializeLogs('password');
    this.initializeLogs('name');
    this.initializeLogs('mail');
    this.initializeLogs('phone');
    this.initializeLogs('address');
    this.initializeLogs('birthDate');
    this.initializeLogs('gender');
    this.initializeLogs('profession');
  }

  public formUsuario = new FormGroup({
    "username": new FormControl(null, [Validators.required, this.validUsername()]),
    "password": new FormControl(null, [Validators.required, this.validPassword()]),
    "name": new FormControl(null, [Validators.required, this.validName()]),
    "mail": new FormControl(null, [Validators.required, this.validMail()]),
    "phone": new FormControl(null, [Validators.required, this.validPhone()]),
    "address": new FormControl(null, [Validators.required]),
    "birthDate": new FormControl(null, [Validators.required, this.validDate()]),
    "gender": new FormControl(null, [Validators.required, this.validGender()]),
    "profession": new FormControl(null, [Validators.required, this.validProfession()]),
  });

  submitForm() {
    if (this.formUsuario.valid) {
      const jsonStr = JSON.stringify(this.formUsuario.value);
      const blob = new Blob([jsonStr], { type: "application/json" });
      const url = URL.createObjectURL(blob);
      this.formUsuario.reset();
      this.formLogService.registerEvent({
        event: "Acionado método 'submit' do formulário",
        element: "formUsuario",
        description: `Formulário Enviado`,
        dateTime: new Date()
      })
      window.open(url);
    }
  }

  validUsername(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      let errors = {};
      const value = control.value || "";

      if (!/[a-zA-Z0-9]/.test(value)) {
        errors = { ...errors, 'specialCharacters': { "status": true, "message": "Nome de usuário deve conter apenas letras e números" } };
      }

      if (value.length > 12) {
        errors = { ...errors, 'maxLength': { "status": false, "message": "Nome de usuário deve ter no maximo 12 caracteres" } };
      }

      if (value.includes(" ")) {
        errors = { ...errors, 'haveWhiteSpaces': { "status": true, "message": "Nome de usuário não deve conter espaços" } };
      }

      if (errors) {
        return errors;
      }

      return null;
    }
  }

  validPassword(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      let errors = {};
      const value = control.value || "";

      if (value.length < 4) {
        errors = { ...errors, 'minLength': { "status": false, "message": "Senha deve ter pelo menos 4 caracteres" } };
      }

      if (!(/[A-Z]/g.test(value))) {
        errors = { ...errors, 'haveUppercase': { "status": false, "message": "Deve conter pelo menos uma letra maiúscula" } };
      }

      if (!(/[^a-zA-Z0-9]/g.test(value))) {
        errors = { ...errors, 'haveSymbol': { "status": false, "message": "Deve conter pelo menos um caractere especial" } };
      }

      if (errors) {
        return errors;
      }

      return null;
    }
  }

  validName(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      let errors = {};
      const value = control.value || "";

      if (value.split(" ").filter((e: string) => e).length <= 1) {
        errors = { ...errors, 'haveSurname': { "status": false, "message": "Deve conter pelo menos um sobrenome" } };
      }

      if (errors) {
        return errors;
      }

      return null;
    }
  }

  validMail(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      let errors = {};
      const regexMail = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      const value = control.value || "";

      if (!(regexMail.test(value))) {
        errors = { ...errors, 'validMail': { "status": false, "message": "Email inválido" } };
      }

      if (errors) {
        return errors;
      }

      return null;
    }
  }

  validPhone(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      let errors = {};
      const value = control.value || "";

      if (!(/\([0-9]{2}\) 9[0-9]{4}-[0-9]{4}/.test(value))) {
        errors = { ...errors, 'validNumber': { "status": false, "message": "Número de telefone inválido" } };
      }

      if (errors) {
        return errors;
      }

      return null;
    }
  }

  validDate(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      let errors = {};
      const value = control.value || "";

      let date = new Date(value);

      if (isNaN(date.getTime())) {
        errors = { ...errors, 'validDate': { "status": false, "message": "Data inválida" } };
      }

      if (errors) {
        return errors;
      }

      return null;
    }
  }

  validGender(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      let errors = {};
      const value = control.value || "";

      if (!this.genderOptions.includes(value)) {
        errors = { ...errors, 'validGender': { "status": false, "message": "Selecione um gênero da lista" } };
      }

      return null;
    }
  }

  validProfession(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      let errors = {};
      const value = control.value || "";

      if (!this.professionOptions.includes(value)) {
        errors = { ...errors, 'validProfession': { "status": false, "message": "Selecione uma profissão da lista" } };
      }

      return null;
    }
  }

  public initializeLogs(element: string) {
    this.formUsuario.get(element)?.statusChanges.subscribe(status => {
      this.formLogService.registerEvent({
        event: "Alteração no estado do campo",
        element: element,
        description: `Status do campo ${element} foi alterado para '${status}'`,
        dateTime: new Date()
      });
    });

    this.formUsuario.get(element)?.valueChanges.subscribe(value => {
      this.formLogService.registerEvent({
        event: "Alteração no valor do campo",
        element: element,
        description: `Valor do campo ${element} foi alterado para '${value}'`,
        dateTime: new Date()
      });
    });
  }
}
