import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SessaoRoutingModule } from './sessao-routing.module';
import { AddSessaoComponent } from './components/add-sessao/add-sessao.component';
import { CardSessaoComponent } from './components/card-sessao/card-sessao.component';
import { DetalhesSessaoComponent } from './components/detalhes-sessao/detalhes-sessao.component';
import { ListaSessoesComponent } from './components/lista-sessoes/lista-sessoes.component';
import { RealizarSessaoComponent } from './components/realizar-sessao/realizar-sessao.component';
import { SharedModule } from '../shared/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthModule } from '../auth/auth.module';
import { MenubarModule } from 'primeng/menubar';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DividerModule } from 'primeng/divider';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { MenuModule } from 'primeng/menu';
import { DataViewModule } from 'primeng/dataview';
import { PickListModule } from 'primeng/picklist';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { TableModule } from 'primeng/table';
import { ChartModule } from 'primeng/chart';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';


@NgModule({
  declarations: [
    AddSessaoComponent,
    CardSessaoComponent,
    DetalhesSessaoComponent,
    ListaSessoesComponent,
    RealizarSessaoComponent
  ],
  imports: [
    CommonModule,
    SessaoRoutingModule,
    SharedModule,

    AuthModule,

    TableModule,
    ChartModule,
    DropdownModule,
    InputTextModule,
    InputTextareaModule,
    CalendarModule,
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
export class SessaoModule { }
