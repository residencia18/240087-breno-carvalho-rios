import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SuinoViewModel } from '../../../../models/Suino/SuinoViewModel';
import { AtividadeViewModel } from '../../../../models/Atividade/AtividadeViewModel';
import { SessaoViewModel } from '../../../../models/Sessao/SessaoViewModel';
import { SessaoService } from '../../../../services/sessao.service';
import { SuinoService } from '../../../../services/suino.service';
import { AtividadeService } from '../../../../services/atividade.service';
import { SessaoInputModel } from '../../../../models/Sessao/SessaoInputModel';


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
  private _atividades: AtividadeViewModel[] = [];
  public id = this.route.snapshot.paramMap.get('id');
  public sessao: SessaoViewModel = {} as SessaoViewModel;
  public suinos: SuinoViewModel[] = [];
  public atividades: AtividadeViewModel[] = [];
  public selectedSuinos: SuinoViewModel[] = [];
  public selectedAtividades: AtividadeViewModel[] = [];

  constructor(
    private service: SessaoService,
    private suinoService: SuinoService,
    private atividadesService: AtividadeService,
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  addSessaoForm: FormGroup = new FormGroup({
    nome: new FormControl(null, [Validators.required]),
    data: new FormControl(null, [Validators.required]),
  });

  async ngOnInit() {
    await this.getDataFromDb().then(() => {
      if (this.id) {
        this.filterDataFromDb(this.id);
      }
    });
  }

  public async filterDataFromDb(id: string) {
    this.service.getById(id).subscribe(sessao => {
      this.sessao = sessao;
      this.addSessaoForm.patchValue(sessao);
      this.selectedSuinos = sessao.suinos;
      this.selectedAtividades = sessao.atividades;

      this.suinos = this._suinos.filter(suino => !this.sessao.suinos.some(s => s.brinco == suino.brinco));
      this.atividades = this._atividades.filter(atividade => !this.sessao.atividades.some(v => v.nome == atividade.nome));
    });
  }

  public async getDataFromDb() {
    this.suinoService.getAll().subscribe(suinos => {
      this._suinos = suinos;
      this.suinos = this._suinos;
    });
    this.atividadesService.getAll().subscribe(atividades => {
      this._atividades = atividades;
      this.atividades = this._atividades;
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
    const sessao = this.getDataFromForm();
    if (this.addSessaoForm.invalid) {
      Swal.fire({
        title: 'Erro!',
        icon: 'error',
        text: 'Ops... Todos os campos são obrigatórios',
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
    if (this.selectedSuinos.length < 1 || this.selectedAtividades.length < 1) {
      Swal.fire({
        title: 'Erro!',
        icon: 'error',
        text: 'Ops... É necessário pelo menos um suino e uma atividade para atualizar.',
        showConfirmButton: true,
      });
      console.error('Por favor, adicione pelo menos um suino e uma atividade antes de atualizar.');
      return;
    }

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
    const atividades = this.selectedAtividades;
    const realizacoes: any = [];

    suinos.forEach(suino => {
      const _realizacoesSuino: any = { suino: '', atividades: [] };
      atividades.forEach(atividade => {
        let realizada = false;
        let updatedAt = new Date().toISOString();
        _realizacoesSuino.suino = suino.brinco;
        if (this.id) {
          let _realizacao: any = this.sessao.realizacoes.find(a => parseInt(a.suino) == suino.brinco);
          let _atividade: any;

          if (_realizacao) {
            _atividade = _realizacao.atividades.find((v: any) => v.nome == atividade.nome);
          }

          if (_atividade) {
            realizada = _atividade.realizada;
            updatedAt = _atividade.updatedAt;
          }
        }

        _realizacoesSuino.atividades.push({
          nome: atividade.nome,
          realizada: realizada,
          updatedAt: updatedAt
        })
      })

      realizacoes.push(_realizacoesSuino);
    });

    let sessao: SessaoInputModel = {
      nome: this.addSessaoForm.value.nome,
      data: this.addSessaoForm.value.data,
      suinos: this.selectedSuinos,
      atividades: this.selectedAtividades,
      realizacoes: realizacoes
    };

    return sessao;
  }
}
