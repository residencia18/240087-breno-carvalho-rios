import { SuinoService } from '../../../services/suino.service';
import { Component } from '@angular/core';
import { PesoViewModel } from '../../../models/Peso/PesoViewModel';
import { PesoService } from '../../../services/peso.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PesoInputModel } from '../../../models/Peso/PesoInputModel';
import { SuinoViewModel } from '../../../models/Suino/SuinoViewModel';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-peso',
  templateUrl: './add-peso.component.html',
  styleUrl: './add-peso.component.css'
})
export class AddPesoComponent {
  suinoOptions: SuinoViewModel[] = [];

  public id = this.route.snapshot.paramMap.get('id');
  public suinoId = this.route.snapshot.paramMap.get('suinoId');
  public peso: PesoViewModel = {} as PesoViewModel;
  public suino: SuinoViewModel = {} as SuinoViewModel;

  constructor(private suinoService: SuinoService, private service: PesoService, private router: Router, private route: ActivatedRoute) { }

  pesoForm: FormGroup = new FormGroup({
    brinco: new FormControl(null, [Validators.required, Validators.maxLength(4), Validators.pattern('^[0-9]*$')]),
    peso: new FormControl(null, [Validators.required, Validators.pattern('^[0-9]+(\.[0-9]+)?$')]),
    data: new FormControl(null, [Validators.required, this.dataPesoValidator.bind(this)]),
  });

  ngOnInit() {
    if (!this.suinoId) {
      this.router.navigate([`/`]);
      return;
    }

    if (!this.id) {
      return;
    }

    this.service.getById(this.id, this.suinoId).subscribe(peso => {
      this.peso = peso;
      this.pesoForm.patchValue(peso);
      this.pesoForm.value.brinco = this.suinoId;
    });
  }

  public submit() {
    if (this.id) {
      this.update(this.id);
      return;
    }

    this.create();
  }

  public create() {
    const peso = this.getDataFromForm();

    this.suinoService.getById(this.suinoId!).subscribe({
      next: (suino: SuinoViewModel) => {
        if (this.isStatusAtivo(suino)) {
          if (this.validatePesagemDate(peso, suino.dataNascimento)) {
            this.addPeso(peso);
          }
        }
      },
      error: (error: any) => {
        this.handleSuinoError(error);
      }
    });
  }

  private isStatusAtivo(suino: SuinoViewModel): boolean {
    if (!suino || suino.status !== "Ativo") {
      this.showSuinoNotFoundError();
      return false;
    }
    return true;
  }

  private validatePesagemDate(peso: any, dataNascimento: Date): boolean {
    if (new Date(peso.data) < new Date(dataNascimento) || new Date(peso.data) > new Date()) {
      this.showPesagemDateError();
      return false;
    }
    return true;
  }

  private addPeso(peso: any) {
    this.service.create(this.suinoId!, peso).subscribe({
      next: (_) => {
        this.router.navigate([`/suinos/detalhes/${this.suinoId}`]);
      },
      error: (error: any) => {
        this.handlePesoError(error);
      }
    });
  }

  private handleSuinoError(error: any) {
    console.error("Erro ao obter informações do suíno:", error);
    Swal.fire({
      title: 'Erro!',
      text: 'Ocorreu um erro ao obter informações do suíno. Por favor, tente novamente mais tarde.',
      icon: 'error',
      confirmButtonText: 'OK'
    });
  }

  private showSuinoNotFoundError() {
    Swal.fire({
      title: 'Erro!',
      text: 'Não é possível adicionar um peso para um suíno que não está ativo ou não foi encontrado!',
      icon: 'error',
      confirmButtonText: 'OK'
    });
  }

  private showPesagemDateError() {
    Swal.fire({
      title: 'Erro!',
      text: 'A data de pesagem não pode ser anterior à data de nascimento do suíno ou posterior à data atual!',
      icon: 'error',
      confirmButtonText: 'OK'
    });
  }

  private handlePesoError(error: any) {
    console.error("Erro ao criar peso:", error);
    Swal.fire({
      title: 'Erro!',
      text: 'Ocorreu um erro ao criar o peso. Por favor, tente novamente mais tarde.',
      icon: 'error',
      confirmButtonText: 'OK'
    });
  }

  public update(id: string) {
    const peso = this.getDataFromForm();

    this.service.update(id, this.suinoId!, peso).subscribe(_ => {
      this.router.navigate([`/suinos/detalhes/${this.suinoId}`]);
    });
  }

  public getDataFromForm(): PesoInputModel {
    let suino: PesoInputModel = {
      peso: this.pesoForm.value.peso,
      data: this.pesoForm.value.data,
    }

    return suino;
  }

  public dataPesoValidator(control: FormControl): { [s: string]: boolean } {
    const dataNascimento = control.value;

    if (dataNascimento && new Date(dataNascimento) > new Date()) {
      return { 'dataPesoFutura': true };
    }

    return {};
  }
}
