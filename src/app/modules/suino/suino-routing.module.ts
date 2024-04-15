import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSuinoComponent } from './components/add-suino/add-suino.component';
import { DetalhesSuinoComponent } from './components/detalhes-suino/detalhes-suino.component';
import { ListaSuinosComponent } from './components/lista-suinos/lista-suinos.component';
import { HistoricoSuinoComponent } from './components/historico-suino/historico-suino.component';
import { HistoricoAtividadesComponent } from './components/historico-atividades/historico-atividades.component';

const routes: Routes = [
  { path: "novo", component: AddSuinoComponent },
  { path: "editar/:id", component: AddSuinoComponent },
  { path: "detalhes/:id", component: DetalhesSuinoComponent },
  { path: "historico/:id", component: HistoricoSuinoComponent },
  { path: "atividades/:id", component: HistoricoAtividadesComponent },
  { path: "", component: ListaSuinosComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SuinoRoutingModule { }