import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SuinoRoutingModule } from './suino-routing.module';
import { ListaSuinosComponent } from './components/lista-suinos/lista-suinos.component';
import { CardSuinoComponent } from './components/card-suino/card-suino.component';
import { DetalhesSuinoComponent } from './components/detalhes-suino/detalhes-suino.component';
import { AddSuinoComponent } from './components/add-suino/add-suino.component';
import { CardPesoComponent } from './components/card-peso/card-peso.component';
import { TableModule } from 'primeng/table';
import { ChartModule } from 'primeng/chart';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { SharedModule } from '../shared/shared.module';
import { DividerModule } from 'primeng/divider';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { MenuModule } from 'primeng/menu';
import { DataViewModule } from 'primeng/dataview';
import { PickListModule } from 'primeng/picklist';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthModule } from '../auth/auth.module';
import { MenubarModule } from 'primeng/menubar';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    //ListaSuinosComponent,
    //CardSuinoComponent,
    //DetalhesSuinoComponent,
    //AddSuinoComponent,
    //CardPesoComponent
  ],
  imports: [
    CommonModule,
    SuinoRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    AuthModule,
    ReactiveFormsModule,

    TableModule,
    ChartModule,
    DropdownModule,
    InputTextModule,
    InputTextareaModule,
    CalendarModule,
    SharedModule,
    DividerModule,
    ButtonModule,
    CardModule,
    MenuModule,
    MenubarModule,
    DataViewModule,
    MenuModule,
    PickListModule,
    TableModule,
    ToggleButtonModule
  ]

})
export class SuinoModule { }
