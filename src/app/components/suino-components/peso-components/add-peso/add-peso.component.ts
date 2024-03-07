import { Component } from '@angular/core';
import { PesoViewModel } from '../../../../models/Peso/PesoViewModel';
import { PesoService } from '../../../../services/peso.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PesoInputModel } from '../../../../models/Peso/PesoInputModel';
import { SuinoViewModel } from '../../../../models/Suino/SuinoViewModel';
import { SuinoService } from '../../../../services/suino.service';

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

  constructor(private service: PesoService, private router: Router, private route: ActivatedRoute) { }

  pesoForm: FormGroup = new FormGroup({
    brinco: new FormControl(null, Validators.required),
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

    this.service.create(this.suinoId!, peso).subscribe(_ => {
      this.router.navigate([`/suinos/detalhes/${this.suinoId}`]);
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
