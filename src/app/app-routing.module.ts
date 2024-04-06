import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSuinoComponent } from './components/suino-components/add-suino/add-suino.component';
import { ListaSuinosComponent } from './components/suino-components/lista-suinos/lista-suinos.component';
import { DetalhesSuinoComponent } from './components/suino-components/detalhes-suino/detalhes-suino.component';
import { authGuard } from './guards/auth.guard';
import { AddPesoComponent } from './components/peso-components/add-peso/add-peso.component';
import { ListaSessoesComponent } from './components/sessao-components/lista-sessoes/lista-sessoes.component';
import { AddSessaoComponent } from './components/sessao-components/add-sessao/add-sessao.component';
import { DetalhesSessaoComponent } from './components/sessao-components/detalhes-sessao/detalhes-sessao.component';
import { RealizarSessaoComponent } from './components/sessao-components/realizar-sessao/realizar-sessao.component';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: "app",
    canActivate: [authGuard],
    children: [
      {
        path: "suinos",
        children: [
          { path: "novo", component: AddSuinoComponent },
          { path: "editar/:id", component: AddSuinoComponent },
          { path: "detalhes/:id", component: DetalhesSuinoComponent },
          { path: "", component: ListaSuinosComponent }
        ]
      },
      {
        path: "",
        children: [
          {
            path: "pesos",
            children: [
              { path: "novo/:suinoId", component: AddPesoComponent },
              { path: "editar/:suinoId/:id", component: AddPesoComponent },
              { path: "detalhes/:suinoId/:id", component: DetalhesSuinoComponent },
              { path: "", component: ListaSuinosComponent }
            ]
          },
          { path: "", component: ListaSuinosComponent }
        ]
      },
      {
        path: "atividades",
        loadChildren: () => import('./modules/atividades/atividades.module').then(m => m.AtividadesModule)
      },
      {
        path: "",
        children: [
          {
            path: "sessoes",
            children: [
              { path: "nova", component: AddSessaoComponent },
              { path: "editar/:id", component: AddSessaoComponent },
              { path: "detalhes/:id", component: DetalhesSessaoComponent },
              { path: "realizar/:id", component: RealizarSessaoComponent },
              { path: "", component: ListaSessoesComponent }
            ]
          },
          { path: "", component: ListaSessoesComponent }
        ]
      },
      { path: "", component: ListaSuinosComponent }
    ]
  },
  { path: '', redirectTo: 'app/suinos', pathMatch: 'full' },
  { path: '**', redirectTo: 'app/suinos' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
