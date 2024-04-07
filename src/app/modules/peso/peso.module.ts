import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PesoRoutingModule } from './peso-routing.module';
import { AddPesoComponent } from './components/add-peso/add-peso.component';
import { TableModule } from 'primeng/table';
import { ChartModule } from 'primeng/chart';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { SharedModule } from 'primeng/api';
import { DividerModule } from 'primeng/divider';
import { ButtonModule } from 'primeng/button';
import { MenuModule } from 'primeng/menu';
import { DataViewModule } from 'primeng/dataview';
import { CardModule } from 'primeng/card';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddPesoComponent
  ],
  imports: [
    CommonModule,
    PesoRoutingModule,
    ReactiveFormsModule,

    TableModule,
    ChartModule,
    DropdownModule,
    InputTextModule,
    CalendarModule,
    SharedModule,
    DividerModule,
    ButtonModule,
    CardModule,
    MenuModule,
    DataViewModule
  ]
})
export class PesoModule { }
