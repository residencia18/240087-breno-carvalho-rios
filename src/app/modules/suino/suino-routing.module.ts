import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSuinoComponent } from './components/add-suino/add-suino.component';
import { DetalhesSuinoComponent } from './components/detalhes-suino/detalhes-suino.component';
import { ListaSuinosComponent } from './components/lista-suinos/lista-suinos.component';

const routes: Routes = [
  { path: "novo", component: AddSuinoComponent },
  { path: "editar/:id", component: AddSuinoComponent },
  { path: "detalhes/:id", component: DetalhesSuinoComponent },
  { path: "", component: ListaSuinosComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SuinoRoutingModule { }
