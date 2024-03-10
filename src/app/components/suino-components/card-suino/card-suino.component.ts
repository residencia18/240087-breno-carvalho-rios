import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SuinoViewModel } from '../../../models/Suino/SuinoViewModel';
import { SuinoService } from '../../../services/suino.service';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-card-suino',
  templateUrl: './card-suino.component.html',
  styleUrl: './card-suino.component.css'
})
export class CardSuinoComponent {
  @Input() suino: SuinoViewModel = {} as SuinoViewModel;
  @Output() onDelete: any = new EventEmitter();

  constructor(private service: SuinoService, private router: Router) { }

  public contextMenuItems: MenuItem[] = [
    { label: 'Excluir', command: _ => this.delete(this.suino.id) },
    { label: 'Editar', command: _ => this.update(this.suino.id) },
    { label: 'Pesar', command: _ => this.pesar(this.suino.id) },
    { label: 'Ver Detalhes', command: _ => this.view(this.suino.id) },
  ]

  public delete(id: string) {
    this.service.delete(id).subscribe(_ => {
      this.onDelete.emit();
    });
  }

  public update(id: string) {
    this.router.navigate([`/suinos/editar/${id}`]);
  }

  public view(id: string) {
    this.router.navigate([`/suinos/detalhes/${id}`]);
  }

  public pesar(id: string) {
    this.router.navigate([`/pesos/novo/${id}`]);
  }

  public calculateAge(dataNascimento: Date | string): number {
    // Se dataNascimento for uma string, converte para Date
    if (typeof dataNascimento === 'string') {
      dataNascimento = new Date(dataNascimento);
    }
    const hoje = new Date();
    const anoAtual = hoje.getFullYear();
    const mesAtual = hoje.getMonth() + 1;
    const diaAtual = hoje.getDate();

    const anoNascimento = dataNascimento.getFullYear();
    const mesNascimento = dataNascimento.getMonth() + 1;
    const diaNascimento = dataNascimento.getDate();

    let idade = anoAtual - anoNascimento;

    if (mesAtual < mesNascimento || (mesAtual === mesNascimento && diaAtual < diaNascimento)) {
      idade--;
    }

    return idade;
  }

}