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
        loadChildren: () => import('./modules/suino/suino.module').then(m => m.SuinoModule)
      },
      {
        path: "pesos",
        loadChildren: () => import('./modules/peso/peso.module').then(m => m.PesoModule)
      },
      {
        path: "atividades",
        loadChildren: () => import('./modules/atividades/atividades.module').then(m => m.AtividadesModule)
      },
      {
        path: "sessoes",
        loadChildren: () => import('./modules/sessao/sessao.module').then(m => m.SessaoModule)
      },
      { path: "", redirectTo: "app/suinos", pathMatch: "full" }
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
