import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { DataViewModule } from 'primeng/dataview';
import { CardModule } from 'primeng/card';
import { MenubarModule } from 'primeng/menubar';
import { ListaAtendimentosComponent } from './components/lista-atendimentos/lista-atendimentos.component';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';

import { HttpClientModule } from '@angular/common/http';
import { AddAtendimentoComponent } from './components/add-atendimento/add-atendimento.component';
import { CardAtendimentoComponent } from './components/card-atendimento/card-atendimento.component';
import { DetalhesAtendimentoComponent } from './components/detalhes-atendimento/detalhes-atendimento.component';

@NgModule({
  declarations: [
    AppComponent,
    AddAtendimentoComponent,
    ListaAtendimentosComponent,
    CardAtendimentoComponent,
    DetalhesAtendimentoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    DataViewModule,
    CardModule,
    MenubarModule,
    InputTextModule,
    InputTextareaModule,
    ButtonModule,
    DividerModule,
    DropdownModule,
    CalendarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
