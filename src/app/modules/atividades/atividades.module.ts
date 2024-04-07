import { NgModule } from '@angular/core';
import { AddAtividadeComponent } from './components/add-atividade/add-atividade.component';
import { CardAtividadeComponent } from './components/card-atividade/card-atividade.component';
import { ListaAtividadesComponent } from './components/lista-atividades/lista-atividades.component';
import { DividerModule } from 'primeng/divider';
import { ButtonModule } from 'primeng/button';
import { Card, CardModule } from 'primeng/card';
import { MenuModule } from 'primeng/menu';
import { DataViewModule } from 'primeng/dataview';
import { InputTextModule } from 'primeng/inputtext';
import { SharedModule } from '../shared/shared.module';
import { AtividadesRoutingModule } from './atividades-routing.module';
import { TableModule } from 'primeng/table';
import { ChartModule } from 'primeng/chart';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';


@NgModule({
  declarations: [
    AddAtividadeComponent,
    CardAtividadeComponent,
    ListaAtividadesComponent,
  ],
  imports: [
    AtividadesRoutingModule,
    SharedModule,
    DividerModule,
    ButtonModule,
    CardModule,
    MenuModule,
    DataViewModule,
    TableModule,
    ChartModule,
    DropdownModule,
    InputTextModule,
    CalendarModule
  ]
})
export class AtividadesModule { }
