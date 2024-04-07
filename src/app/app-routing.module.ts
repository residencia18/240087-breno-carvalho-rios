import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './guards/auth.guard';
import { DetalhesSuinoComponent } from './modules/suino/components/detalhes-suino/detalhes-suino.component';
import { ListaSuinosComponent } from './modules/suino/components/lista-suinos/lista-suinos.component';
import { AddPesoComponent } from './modules/peso/components/add-peso/add-peso.component';
import { AddSessaoComponent } from './modules/sessao/components/add-sessao/add-sessao.component';
import { DetalhesSessaoComponent } from './modules/sessao/components/detalhes-sessao/detalhes-sessao.component';
import { RealizarSessaoComponent } from './modules/sessao/components/realizar-sessao/realizar-sessao.component';
import { ListaSessoesComponent } from './modules/sessao/components/lista-sessoes/lista-sessoes.component';
import { AddSuinoComponent } from './modules/suino/components/add-suino/add-suino.component';


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
