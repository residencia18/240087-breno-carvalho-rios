import { SuinoService } from './../../../../services/suino.service';
import { Component } from '@angular/core';
import { PesoViewModel } from '../../../../models/Peso/PesoViewModel';
import { PesoService } from '../../../../services/peso.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PesoInputModel } from '../../../../models/Peso/PesoInputModel';
import { SuinoViewModel } from '../../../../models/Suino/SuinoViewModel';
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
    peso: new FormControl(null, Validators.required),
    data: new FormControl(null, Validators.required),
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

    // Obter informações do suíno com base no suinoId
    this.suinoService.getById(this.suinoId!).subscribe({
      next: (suino: SuinoViewModel) => {

        // Verificar se o suíno está ativo
        if (suino && suino.status === "Ativo") {
          // Verificar se a data de pesagem é posterior à data de nascimento do suíno
          if (new Date(peso.data) < new Date(suino.dataNascimento)) {
            Swal.fire({
              title: 'Erro!',
              text: 'A data de pesagem não pode ser anterior à data de nascimento do suíno!',
              icon: 'error',
              confirmButtonText: 'OK'
            });
            return; // Encerrar a execução da função create()
          }

          // Suíno está ativo e a data de pesagem é válida, então pode adicionar o peso
          this.service.create(this.suinoId!, peso).subscribe({
            next: (_) => {
              this.router.navigate([`/suinos/detalhes/${this.suinoId}`]);
            },
            error: (error: any) => {
              console.error("Erro ao criar peso:", error);
              Swal.fire({
                title: 'Erro!',
                text: 'Ocorreu um erro ao criar o peso. Por favor, tente novamente mais tarde.',
                icon: 'error',
                confirmButtonText: 'OK'
              });
            }
          });
        } else {
          // Suíno não está ativo ou não foi encontrado, exiba uma mensagem de erro
          Swal.fire({
            title: 'Erro!',
            text: 'Não é possível adicionar um peso para um suíno que não está ativo ou não foi encontrado!',
            icon: 'error',
            confirmButtonText: 'OK'
          });
        }
      },
      error: (error: any) => {
        // Tratar erros ao obter informações do suíno
        console.error("Erro ao obter informações do suíno:", error);
        Swal.fire({
          title: 'Erro!',
          text: 'Ocorreu um erro ao obter informações do suíno. Por favor, tente novamente mais tarde.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
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
}
