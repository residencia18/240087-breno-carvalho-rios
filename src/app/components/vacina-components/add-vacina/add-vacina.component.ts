import { Component } from '@angular/core';
import { VacinaViewModel } from '../../../models/Vacina/VacinaViewModel';
import { VacinaService } from '../../../services/vacina.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { VacinaInputModel } from '../../../models/Vacina/VacinaInputModel';

@Component({
  selector: 'app-add-vacina',
  templateUrl: './add-vacina.component.html',
  styleUrl: './add-vacina.component.css'
})
export class AddVacinaComponent {
  public id = this.route.snapshot.paramMap.get('id');
  public vacina: VacinaViewModel = {} as VacinaViewModel;

  constructor(private service: VacinaService, private router: Router, private route: ActivatedRoute) { }

  vacinaForm: FormGroup = new FormGroup({
    nome: new FormControl(null, [Validators.required]),
  });

  ngOnInit() {
    if (!this.id) {
      return;
    }

    this.service.getById(this.id).subscribe(vacina => {
      this.vacina = vacina;
      this.vacinaForm.patchValue(vacina);
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
    const vacina = this.getDataFromForm();

    this.service.create(vacina).subscribe({
      next: _ => {
        this.router.navigate(['app/vacinas']);
      },
      error: (error: any) => {
        this.handleVacinaError(error);
      }
    });
  }

  public update(id: string) {
    const vacina = this.getDataFromForm();

    this.service.update(id, vacina).subscribe(_ => {
      this.router.navigate([`app/vacinas/detalhes/${this.id}`]);
    });
  }

  public getDataFromForm(): VacinaInputModel {
    let suino: VacinaInputModel = {
      nome: this.vacinaForm.value.nome,
    }

    return suino;
  }

  private handleVacinaError(error: any) {
    console.error("Erro ao criar vacina:", error);
    Swal.fire({
      title: 'Erro!',
      text: 'Ocorreu um erro ao criar a vacina. Por favor, tente novamente mais tarde.',
      icon: 'error',
      confirmButtonText: 'OK'
    });
  }
}
