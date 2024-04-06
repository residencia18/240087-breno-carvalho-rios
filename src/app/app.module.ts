import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

import { AppComponent } from './app.component';

import { DataViewModule } from 'primeng/dataview';
import { CardModule } from 'primeng/card';
import { MenubarModule } from 'primeng/menubar';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import { ChartModule } from 'primeng/chart';
import { MenuModule } from 'primeng/menu';
import { PickListModule } from 'primeng/picklist';
import { TableModule } from 'primeng/table';
import { ToggleButtonModule } from 'primeng/togglebutton';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AddPesoComponent } from './modules/atividades/components/peso-components/add-peso/add-peso.component';

import { AuthModule } from './modules/auth/auth.module';
import { SharedModule } from './modules/shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { AddSuinoComponent } from './modules/atividades/components/suino-components/add-suino/add-suino.component';
import { CardSuinoComponent } from './modules/atividades/components/suino-components/card-suino/card-suino.component';
import { DetalhesSuinoComponent } from './modules/atividades/components/suino-components/detalhes-suino/detalhes-suino.component';
import { CardPesoComponent } from './modules/atividades/components/suino-components/card-peso/card-peso.component';
import { ListaSuinosComponent } from './modules/atividades/components/suino-components/lista-suinos/lista-suinos.component';
import { AddSessaoComponent } from './modules/atividades/components/sessao-components/add-sessao/add-sessao.component';
import { CardSessaoComponent } from './modules/atividades/components/sessao-components/card-sessao/card-sessao.component';
import { RealizarSessaoComponent } from './modules/atividades/components/sessao-components/realizar-sessao/realizar-sessao.component';
import { ListaSessoesComponent } from './modules/atividades/components/sessao-components/lista-sessoes/lista-sessoes.component';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    // AddSuinoComponent,
    // ListaSuinosComponent,
    // CardSuinoComponent,
    // DetalhesSuinoComponent,
    // AddPesoComponent,
    // CardPesoComponent,
    AddSessaoComponent,
    ListaSessoesComponent,
    CardSessaoComponent,
    // DetalhesSessaoComponent,
    RealizarSessaoComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,

    SharedModule,
    AuthModule,

    DataViewModule,
    CardModule,
    MenubarModule,
    InputTextModule,
    InputTextareaModule,
    ButtonModule,
    DividerModule,
    DropdownModule,
    CalendarModule,
    ChartModule,
    MenuModule,
    PickListModule,
    TableModule,
    ToggleButtonModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: LOCALE_ID, useValue: 'pt-BR' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
