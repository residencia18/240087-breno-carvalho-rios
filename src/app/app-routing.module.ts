import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './guards/auth.guard';


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
