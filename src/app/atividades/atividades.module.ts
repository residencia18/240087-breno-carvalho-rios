import { NgModule } from '@angular/core';
import { AddAtividadeComponent } from './components/add-atividade/add-atividade.component';
import { CardAtividadeComponent } from './components/card-atividade/card-atividade.component';
import { ListaAtividadesComponent } from './components/lista-atividades/lista-atividades.component';
import { DividerModule } from 'primeng/divider';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { MenuModule } from 'primeng/menu';
import { DataViewModule } from 'primeng/dataview';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    AddAtividadeComponent,
    CardAtividadeComponent,
    ListaAtividadesComponent
  ],
  imports: [
    SharedModule,
    DividerModule,
    ButtonModule,
    CardModule,
    MenuModule,
    DataViewModule
  ]
})
export class AtividadesModule { }
