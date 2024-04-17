import { NgModule } from '@angular/core';
import { SuinoRoutingModule } from './suino-routing.module';
import { ListaSuinosComponent } from './components/lista-suinos/lista-suinos.component';
import { CardSuinoComponent } from './components/card-suino/card-suino.component';
import { DetalhesSuinoComponent } from './components/detalhes-suino/detalhes-suino.component';
import { AddSuinoComponent } from './components/add-suino/add-suino.component';
import { CardPesoComponent } from './components/card-peso/card-peso.component';
import { SharedModule } from '../shared/shared.module';
import { ChartModule } from 'primeng/chart';
import { DropdownModule } from 'primeng/dropdown';
import { DividerModule } from 'primeng/divider';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { MenuModule } from 'primeng/menu';
import { DataViewModule } from 'primeng/dataview';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { HistoricoSuinoComponent } from './components/historico-suino/historico-suino.component';
import { HistoricoPesosComponent } from './components/historico-pesos/historico-pesos.component';


@NgModule({
  declarations: [
    ListaSuinosComponent,
    CardSuinoComponent,
    DetalhesSuinoComponent,
    AddSuinoComponent,
    CardPesoComponent,
    HistoricoPesosComponent
  ],
  imports: [
    SuinoRoutingModule,
    SharedModule,
    
    HistoricoSuinoComponent,
    InputTextModule,
    ChartModule,
    DropdownModule,
    DividerModule,
    ButtonModule,
    CardModule,
    MenuModule,
    DataViewModule,
    CalendarModule,
  ]

})
export class SuinoModule { }
