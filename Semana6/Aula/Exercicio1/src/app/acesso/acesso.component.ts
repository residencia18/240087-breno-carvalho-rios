import { Component } from '@angular/core';


@Component({
  selector: 'app-acesso',
  templateUrl: './acesso.component.html',
  styleUrl: './acesso.component.css'
})
export class AcessoComponent {
  usuario : string = '';
  permissao : string = '';
  permitido : boolean = false;
  logado: boolean = false;
  roles: string[] = ['root', 'admin', 'visitante']

  public onLogando() {
    this.permitido = this.roles.includes(this.permissao);
  }

  public login() {
    if(this.permitido) {
      this.logado = true;
    }
  }
}
