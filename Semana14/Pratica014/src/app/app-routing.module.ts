import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAtendimentoComponent } from './components/add-atendimento/add-atendimento.component';
import { ListaAtendimentosComponent } from './components/lista-atendimentos/lista-atendimentos.component';
import { DetalhesAtendimentoComponent } from './components/detalhes-atendimento/detalhes-atendimento.component';
import { AuthComponent } from './components/auth/auth.component';
import { LoginComponent } from './components/auth/login/login.component';
import { SignupComponent } from './components/auth/signup/signup.component';

const routes: Routes = [
  {
    path: 'auth',
    component: AuthComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'signin', component: SignupComponent },
      { path: '', component: LoginComponent },
    ],
  },
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
