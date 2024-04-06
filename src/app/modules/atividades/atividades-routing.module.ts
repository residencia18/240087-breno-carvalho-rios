import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddAtividadeComponent } from "./components/add-atividade/add-atividade.component";
import { ListaAtividadesComponent } from "./components/lista-atividades/lista-atividades.component";

const routes: Routes = [
    { path: "nova", component: AddAtividadeComponent },
    { path: "editar/:id", component: AddAtividadeComponent },
    { path: "", component: ListaAtividadesComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AtividadesRoutingModule { }
