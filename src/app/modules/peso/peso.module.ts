import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PesoRoutingModule } from './peso-routing.module';
import { AddPesoComponent } from './components/add-peso/add-peso.component';
import { TableModule } from 'primeng/table';
import { ChartModule } from 'primeng/chart';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { SharedModule } from '../shared/shared.module';
import { DividerModule } from 'primeng/divider';
import { ButtonModule } from 'primeng/button';
import { MenuModule } from 'primeng/menu';
import { DataViewModule } from 'primeng/dataview';
import { CardModule } from 'primeng/card';


@NgModule({
  declarations: [
    AddPesoComponent
  ],
  imports: [
    CommonModule,
    PesoRoutingModule,
    SharedModule,

    TableModule,
    ChartModule,
    DropdownModule,
    InputTextModule,
    CalendarModule,
    DividerModule,
    ButtonModule,
    CardModule,
    MenuModule,
    DataViewModule
  ]
})
export class PesoModule { }
