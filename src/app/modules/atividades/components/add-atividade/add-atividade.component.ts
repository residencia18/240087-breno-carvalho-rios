import { Component } from '@angular/core';
import { AtividadeViewModel } from '../../../../models/Atividade/AtividadeViewModel';
import { AtividadeService } from '../../../../services/atividade.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { AtividadeInputModel } from '../../../../models/Atividade/AtividadeInputModel';

@Component({
  selector: 'app-add-atividade',
  templateUrl: './add-atividade.component.html',
  styleUrl: './add-atividade.component.css'
})
export class AddAtividadeComponent {
  public id = this.route.snapshot.paramMap.get('id');
  public atividade: AtividadeViewModel = {} as AtividadeViewModel;

  constructor(private service: AtividadeService, private router: Router, private route: ActivatedRoute) { }

  atividadeForm: FormGroup = new FormGroup({
    nome: new FormControl(null, [Validators.required]),
  });

  ngOnInit() {
    if (!this.id) {
      return;
    }

    this.service.getById(this.id).subscribe(atividade => {
      this.atividade = atividade;
      this.atividadeForm.patchValue(atividade);
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
    const atividade = this.getDataFromForm();

    this.service.create(atividade).subscribe({
      next: _ => {
        this.router.navigate(['app/atividades']);
      },
      error: (error: any) => {
        this.handleAtividadeError(error);
      }
    });
  }

  public update(id: string) {
    const atividade = this.getDataFromForm();

    this.service.update(id, atividade).subscribe(_ => {
      this.router.navigate([`app/atividades`]);
    });
  }

  public getDataFromForm(): AtividadeInputModel {
    let suino: AtividadeInputModel = {
      nome: this.atividadeForm.value.nome,
    }

    return suino;
  }

  private handleAtividadeError(error: any) {
    console.error("Erro ao criar atividade:", error);
    Swal.fire({
      title: 'Erro!',
      text: 'Ocorreu um erro ao criar a atividade. Por favor, tente novamente mais tarde.',
      icon: 'error',
      confirmButtonText: 'OK'
    });
  }
}
