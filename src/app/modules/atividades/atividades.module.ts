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
import { AddSuinoComponent } from './components/suino-components/add-suino/add-suino.component';
import { CardPesoComponent } from './components/suino-components/card-peso/card-peso.component';
import { DetalhesSessaoComponent } from './components/sessao-components/detalhes-sessao/detalhes-sessao.component';
import { ListaSuinosComponent } from './components/suino-components/lista-suinos/lista-suinos.component';
import { CardSuinoComponent } from './components/suino-components/card-suino/card-suino.component';
import { DetalhesSuinoComponent } from './components/suino-components/detalhes-suino/detalhes-suino.component';
import { TableModule } from 'primeng/table';
import { ChartModule } from 'primeng/chart';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { AddPesoComponent } from './components/peso-components/add-peso/add-peso.component';


@NgModule({
  declarations: [
    AddAtividadeComponent,
    CardAtividadeComponent,
    ListaAtividadesComponent,
    AddSuinoComponent,
    CardPesoComponent,
    CardSuinoComponent,
    DetalhesSessaoComponent,
    ListaSuinosComponent,
    DetalhesSuinoComponent,
    AddPesoComponent

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
