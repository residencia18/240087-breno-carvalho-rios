import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AtendimentoService } from '../../services/atendimento.service';
import { AtendimentoInputModel } from '../../models/Atendimento/AtendimentoInputModel';
import { AtendimentoViewModel } from '../../models/Atendimento/AtendimentoViewModel';

@Component({
  selector: 'app-add-atendimento',
  templateUrl: './add-atendimento.component.html',
  styleUrl: './add-atendimento.component.css'
})
export class AddAtendimentoComponent {
  public porteOptions = [
    'Pequeno',
    'Medio',
    'Grande',
  ]

  public sexoOptions = [
    'Macho',
    'Fêmea',
  ]

  public statusOptions = [
    'Pendente',
    'Concluído',
    'Cancelado',
  ]

  public id = this.route.snapshot.paramMap.get('id');
  public atendimento: AtendimentoViewModel = {} as AtendimentoViewModel;

  constructor(private service: AtendimentoService, private router: Router, private route: ActivatedRoute) { }

  addAtendimentoForm: FormGroup = new FormGroup({
    // Dados Pessoa
    nomeCliente: new FormControl(null, Validators.required),
    emailCliente: new FormControl(null, Validators.required),
    cpfCliente: new FormControl(null, Validators.required),
    // Dados Pet
    nomePet: new FormControl(null, Validators.required),
    racaPet: new FormControl(null, Validators.required),
    portePet: new FormControl(null, Validators.required),
    sexoPet: new FormControl(null, Validators.required),
    dataNascimentoPet: new FormControl(null, Validators.required),
    // Dados Atendimento
    dataHora: new FormControl(null, Validators.required),
    procedimento: new FormControl(null, Validators.required),
    nomeProfissional: new FormControl(null, Validators.required),
    status: new FormControl("Pendente", Validators.required),
  });

  ngOnInit() {
    if (this.id) {
      this.service.getById(this.id).subscribe(atendimento => {
        this.atendimento = atendimento;
        this.addAtendimentoForm.patchValue(atendimento);
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
    const atendimento = this.getDataFromForm();

    this.service.create(atendimento).subscribe(_ => {
      this.router.navigate(['/']);
    });
  }

  public update(id: string) {
    const atendimento = this.getDataFromForm();

    this.service.update(id, atendimento).subscribe(_ => {
      this.router.navigate([`detalhes/atendimento/${id}`]);
    });
  }

  public getDataFromForm(): AtendimentoInputModel {
    let atendimento: AtendimentoInputModel = {
      nomeCliente: this.addAtendimentoForm.get("nomeCliente")?.value,
      emailCliente: this.addAtendimentoForm.get("emailCliente")?.value,
      cpfCliente: this.addAtendimentoForm.get("cpfCliente")?.value,
      nomePet: this.addAtendimentoForm.get("nomePet")?.value,
      racaPet: this.addAtendimentoForm.get("racaPet")?.value,
      portePet: this.addAtendimentoForm.get("portePet")?.value,
      sexoPet: this.addAtendimentoForm.get("sexoPet")?.value,
      dataNascimentoPet: this.addAtendimentoForm.get("dataNascimentoPet")?.value,
      dataHora: this.addAtendimentoForm.get("dataHora")?.value,
      procedimento: this.addAtendimentoForm.get("procedimento")?.value,
      nomeProfissional: this.addAtendimentoForm.get("nomeProfissional")?.value,
      status: this.addAtendimentoForm.get("status")?.value,
    }

    return atendimento;
  }
}
