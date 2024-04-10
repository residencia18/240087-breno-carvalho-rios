import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSessaoComponent } from './components/add-sessao/add-sessao.component';
import { DetalhesSessaoComponent } from './components/detalhes-sessao/detalhes-sessao.component';
import { RealizarSessaoComponent } from './components/realizar-sessao/realizar-sessao.component';
import { ListaSessoesComponent } from './components/lista-sessoes/lista-sessoes.component';

const routes: Routes = [
  { path: "nova", component: AddSessaoComponent },
  { path: "editar/:id", component: AddSessaoComponent },
  { path: "detalhes/:id", component: DetalhesSessaoComponent },
  { path: "realizar/:id", component: RealizarSessaoComponent },
  { path: "", component: ListaSessoesComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SessaoRoutingModule { }
