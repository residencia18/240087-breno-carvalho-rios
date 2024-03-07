import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SuinoService } from '../../../services/suino.service';
import { SuinoInputModel } from '../../../models/Suino/SuinoInputModel';
import { SuinoViewModel } from '../../../models/Suino/SuinoViewModel';
import { AuthService } from '../../../services/auth.service';

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
    brinco: new FormControl(null, Validators.required),
    brincoPai: new FormControl(null, Validators.required),
    brincoMae: new FormControl(null, Validators.required),
    dataNascimento: new FormControl(null, Validators.required),
    sexo: new FormControl(null, Validators.required),
    dataSaida: new FormControl(null, Validators.required),
    status: new FormControl("Ativo", Validators.required),
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

    this.service.create(suino).subscribe(_ => {
      this.router.navigate(['/']);
    });
  }

  public update(id: string) {
    const suino = this.getDataFromForm();

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
    }

    return suino;
  }
}
