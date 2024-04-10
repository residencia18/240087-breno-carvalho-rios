import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPesoComponent } from './components/add-peso/add-peso.component';
import { DetalhesSuinoComponent } from '../suino/components/detalhes-suino/detalhes-suino.component';

const routes: Routes = [
  { path: "novo/:suinoId", component: AddPesoComponent },
  { path: "editar/:suinoId/:id", component: AddPesoComponent },
  { path: "detalhes/:suinoId/:id", component: DetalhesSuinoComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PesoRoutingModule { }
