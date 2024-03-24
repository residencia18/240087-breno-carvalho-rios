import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SessaoService } from '../../../services/sessao.service';
import { SessaoViewModel } from '../../../models/Sessao/SessaoViewModel';
import { SessaoInputModel } from '../../../models/Sessao/SessaoInputModel';
import { SuinoService } from '../../../services/suino.service';
import { SuinoViewModel } from '../../../models/Suino/SuinoViewModel';
import { VacinaService } from '../../../services/vacina.service';
import { VacinaViewModel } from '../../../models/Vacina/VacinaViewModel';
import Swal from 'sweetalert2';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-sessao',
  templateUrl: './add-sessao.component.html',
  styleUrl: './add-sessao.component.css'
})
export class AddSessaoComponent {
  public sexoOptions = [
    'M',
    'F',
  ]

  public statusOptions = [
    'Ativo',
    'Vendido',
    'Morto',
  ]

  private _suinos: SuinoViewModel[] = [];
  private _vacinas: VacinaViewModel[] = [];
  public id = this.route.snapshot.paramMap.get('id');
  public sessao: SessaoViewModel = {} as SessaoViewModel;
  public suinos: SuinoViewModel[] = [];
  public vacinas: VacinaViewModel[] = [];
  public selectedSuinos: SuinoViewModel[] = [];
  public selectedVacinas: VacinaViewModel[] = [];

  constructor(
    private service: SessaoService,
    private suinoService: SuinoService,
    private vacinasService: VacinaService,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    this.suinoService.getAll().subscribe(suinos => {
      this._suinos = suinos;
      this.suinos = this._suinos;
    });
    this.vacinasService.getAll().subscribe(vacinas => {
      this._vacinas = vacinas;
      this.vacinas = this._vacinas;
    });
  }

  addSessaoForm: FormGroup = new FormGroup({
    nome: new FormControl(null, [Validators.required]),
    data: new FormControl(null, [Validators.required, this.dataFuturaValidator.bind(this)]),
  });

  ngOnInit() {
    if (this.id) {
      this.service.getById(this.id).subscribe(sessao => {
        this.sessao = sessao;
        this.addSessaoForm.patchValue(sessao);
        this.selectedSuinos = sessao.suinos;
        this.selectedVacinas = sessao.vacinas;

        this.suinos = this._suinos.filter(suino => !this.sessao.suinos.some(s => s.brinco == suino.brinco));
        this.vacinas = this._vacinas.filter(vacina => !this.sessao.vacinas.some(v => v.nome == vacina.nome));
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
    const sessao = this.getDataFromForm();
    if (sessao.data && new Date(sessao.data) > new Date() || this.addSessaoForm.invalid) {
      Swal.fire({
        title: 'Erro!',
        icon: 'error',
        text: 'Ops... A data da sessão não pode ser futura e todos os campos são obrigatórios',
        showConfirmButton: true,
      });
      console.error('Por favor, preencha todos os campos obrigatórios antes de criar.');
      return;
    }
    this.service.create(sessao).subscribe({
      next: _ => {
        this.router.navigate(['app/sessoes']);
      }
    })
  }

  public update(id: string) {
    const sessao = this.getDataFromForm();
    if (this.addSessaoForm.invalid) {
      Swal.fire({
        title: 'Erro!',
        icon: 'error',
        text: 'Ops... Preencha todos os campos obrigatórios antes de atualizar.',
        showConfirmButton: true,
      });
      console.error('Por favor, preencha todos os campos obrigatórios antes de atualizar.');
      return;
    }

    this.service.update(id, sessao).subscribe(_ => {
      this.router.navigate([`app/sessoes/detalhes/${id}`]);
    });
  }

  public getDataFromForm(): SessaoInputModel {
    const suinos = this.selectedSuinos;
    const vacinas = this.selectedVacinas;
    const aplicacoes: any = [];

    suinos.forEach(suino => {
      const _vacinas: any = []
      vacinas.forEach(vacina => {
        let aplicada = false;
        // if (this.sessao) {
        //   let _aplicacao: any = this.sessao.aplicacoes.find(a => parseInt(a.suino) == suino.brinco);
        //   let _vacina: any = _aplicacao.vacinas.find((v: any) => v.nome == vacina.nome);
        //   if (_vacina) {
        //     aplicada = _vacina.aplicada;
        //   }
        // }

        _vacinas.push({
          nome: vacina.nome,
          aplicada: aplicada
        })
      })
      aplicacoes.push({
        suino: suino.brinco,
        vacinas: _vacinas
      })
    });

    let sessao: SessaoInputModel = {
      nome: this.addSessaoForm.value.nome,
      data: this.addSessaoForm.value.data,
      suinos: this.selectedSuinos,
      vacinas: this.selectedVacinas,
      aplicacoes: aplicacoes
    };

    return sessao;
  }

  public dataFuturaValidator(control: FormControl): { [s: string]: boolean } {
    const data = control.value;
    if (data && new Date(data) > new Date()) {
      return { 'dataFutura': true };
    }

    return {};
  }

}
