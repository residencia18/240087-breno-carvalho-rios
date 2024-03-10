import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SuinoService } from '../../../services/suino.service';
import { SuinoInputModel } from '../../../models/Suino/SuinoInputModel';
import { SuinoViewModel } from '../../../models/Suino/SuinoViewModel';
import { AuthService } from '../../../services/auth.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-suino',
  templateUrl: './add-suino.component.html',
  styleUrl: './add-suino.component.css'
})
export class AddSuinoComponent {

  public sexoOptions = [
    'M',
    'F',
  ]

  public statusOptions = [
    'Ativo',
    'Vendido',
    'Morto',
  ]

  public id = this.route.snapshot.paramMap.get('id');
  public suino: SuinoViewModel = {} as SuinoViewModel;

  constructor(private service: SuinoService, private router: Router, private route: ActivatedRoute, private authService: AuthService) { }

  addSuinoForm: FormGroup = new FormGroup({
    brinco: new FormControl(null, [Validators.required, Validators.maxLength(4), Validators.pattern('^[0-9]*$')]),
    brincoPai: new FormControl(null, [Validators.required, Validators.maxLength(4), Validators.pattern('^[0-9]*$')]),
    brincoMae: new FormControl(null, [Validators.required, Validators.maxLength(4), Validators.pattern('^[0-9]*$')]),
    dataNascimento: new FormControl(null, [Validators.required, this.dataNascimentoValidator.bind(this)]),
    sexo: new FormControl(null, [Validators.required]),
    dataSaida: new FormControl(null, [Validators.required, this.dataSaidaValidator.bind(this)]),
    status: new FormControl("Ativo", [Validators.required]),
  });

  ngOnInit() {
    if (this.id) {
      this.service.getById(this.id).subscribe(suino => {
        this.suino = suino;
        this.addSuinoForm.patchValue(suino);
      });
    }
  }

  public submit() {
    if (this.id) {
      this.update(this.id);
      return;
    }

    this.create();
  }

  public create() {
    const suino = this.getDataFromForm();

    // Verifica se já existe um suíno com o brinco cadastrado
    this.service.getByBrinco(suino.brinco).subscribe(existingSuino => {
      if (existingSuino !== undefined && existingSuino !== null) {
        Swal.fire({
          title: 'Erro!',
          icon: 'error',
          text: `Já existe um suíno cadastrado com o brinco ${suino.brinco}.`,
          showConfirmButton: true,
        });
        return;
      } else {
        // Se não houver suíno com o mesmo brinco, continua com a criação
        if (!this.isValidForm(suino)) {
          Swal.fire({
            title: 'Erro!',
            icon: 'error',
            text: 'Ops... Houve um erro ao enviar o formulário, verifique os campos e tente novamente.',
            showConfirmButton: true,
          });
          console.error('Por favor, corrija os erros no formulário.');
          return;
        }

        this.service.create(suino).subscribe(_ => {
          this.router.navigate(['/']);
        });
      }
    });
  }

  public update(id: string) {
    const suino = this.getDataFromForm();

    if (!this.isValidForm(suino)) {
      Swal.fire({
        title: 'Erro!',
        icon: 'error',
        text: 'Ops... Preencha todos os campos obrigatórios antes de atualizar.',
        showConfirmButton: true,
      });
      console.error('Por favor, preencha todos os campos obrigatórios antes de atualizar.');
      return;
    }

    this.service.update(id, suino).subscribe(_ => {
      this.router.navigate([`/suinos/detalhes/${id}`]);
    });
  }

  public getDataFromForm(): SuinoInputModel {
    let suino: SuinoInputModel = {
      brinco: this.addSuinoForm.value.brinco,
      brincoPai: this.addSuinoForm.value.brincoPai,
      brincoMae: this.addSuinoForm.value.brincoMae,
      dataNascimento: this.addSuinoForm.value.dataNascimento,
      sexo: this.addSuinoForm.value.sexo,
      dataSaida: this.addSuinoForm.value.dataSaida,
      status: this.addSuinoForm.value.status,
      cadastradoPor: this.authService.usuario.value.email,
    };

    return suino;
  }

  // Verifica se o formulário é válido
  private isValidForm(suino: any): boolean {

    // Verifica se os campos obrigatórios foram preenchidos
    return !!suino.brinco && !!suino.brincoPai && !!suino.brincoMae && !!suino.dataNascimento && !!suino.sexo && !!suino.status;
  }

  // Proibe data de nascimento futura
  public dataNascimentoValidator(control: FormControl): { [s: string]: boolean } {
    const dataNascimento = control.value;

    if (dataNascimento && new Date(dataNascimento) > new Date()) {
      return { 'dataNascimentoFutura': true };
    }

    return {};
  }

  // Proibe data de saída anterior a data de nascimento
  public dataSaidaValidator(control: FormControl): { [s: string]: boolean } {
    const dataNascimento = this.addSuinoForm?.get('dataNascimento')?.value;
    const dataSaida = control.value;

    if (dataNascimento && dataSaida && new Date(dataSaida) <= new Date(dataNascimento)) {
      return { 'dataSaidaAnterior': true };
    }

    if (this.addSuinoForm?.get('status')?.value === 'Ativo' && !dataSaida) {
      return { 'dataSaidaRequerida': true };
    }

    return {};
  }

}