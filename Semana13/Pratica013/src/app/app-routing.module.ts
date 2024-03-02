import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAtendimentoComponent } from './components/add-atendimento/add-atendimento.component';
import { ListaAtendimentosComponent } from './components/lista-atendimentos/lista-atendimentos.component';
import { DetalhesAtendimentoComponent } from './components/detalhes-atendimento/detalhes-atendimento.component';

const routes: Routes = [
  { path: "novo/atendimento", component: AddAtendimentoComponent },
  { path: "editar/atendimento/:id", component: AddAtendimentoComponent },
  { path: "detalhes/atendimento/:id", component: DetalhesAtendimentoComponent },
  { path: "", component: ListaAtendimentosComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
