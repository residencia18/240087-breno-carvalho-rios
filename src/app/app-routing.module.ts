import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSuinoComponent } from './components/suino-components/add-suino/add-suino.component';
import { ListaSuinosComponent } from './components/suino-components/lista-suinos/lista-suinos.component';
import { DetalhesSuinoComponent } from './components/suino-components/detalhes-suino/detalhes-suino.component';
import { AuthComponent } from './components/auth/auth.component';
import { LoginComponent } from './components/auth/login/login.component';
import { SignupComponent } from './components/auth/signup/signup.component';
import { authGuard } from './guards/auth.guard';
import { AddPesoComponent } from './components/peso-components/add-peso/add-peso.component';

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
  {
    path: "",
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
        canActivate: [authGuard],
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
      { path: "", component: ListaSuinosComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
