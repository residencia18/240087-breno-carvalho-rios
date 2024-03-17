import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { DataViewModule } from 'primeng/dataview';
import { CardModule } from 'primeng/card';
import { MenubarModule } from 'primeng/menubar';
import { ListaSuinosComponent } from './components/suino-components/lista-suinos/lista-suinos.component';
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

import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AddSuinoComponent } from './components/suino-components/add-suino/add-suino.component';
import { CardSuinoComponent } from './components/suino-components/card-suino/card-suino.component';
import { DetalhesSuinoComponent } from './components/suino-components/detalhes-suino/detalhes-suino.component';
import { AuthComponent } from './components/auth/auth.component';
import { LoginComponent } from './components/auth/login/login.component';
import { SignupComponent } from './components/auth/signup/signup.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AddPesoComponent } from './components/peso-components/add-peso/add-peso.component';
import { CardPesoComponent } from './components/suino-components/card-peso/card-peso.component';
import { AddVacinaComponent } from './components/vacina-components/add-vacina/add-vacina.component';
import { ListaVacinasComponent } from './components/vacina-components/lista-vacinas/lista-vacinas.component';
import { CardVacinaComponent } from './components/vacina-components/card-vacina/card-vacina.component';
import { AddSessaoComponent } from './components/sessao-components/add-sessao/add-sessao.component';
import { ListaSessoesComponent } from './components/sessao-components/lista-sessoes/lista-sessoes.component';
import { CardSessaoComponent } from './components/sessao-components/card-sessao/card-sessao.component';
import { DetalhesSessaoComponent } from './components/sessao-components/detalhes-sessao/detalhes-sessao.component';
import { RealizarSessaoComponent } from './components/sessao-components/realizar-sessao/realizar-sessao.component';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    AddSuinoComponent,
    ListaSuinosComponent,
    CardSuinoComponent,
    DetalhesSuinoComponent,
    AuthComponent,
    LoginComponent,
    SignupComponent,
    AddPesoComponent,
    CardPesoComponent,
    AddVacinaComponent,
    ListaVacinasComponent,
    CardVacinaComponent,
    AddSessaoComponent,
    ListaSessoesComponent,
    CardSessaoComponent,
    DetalhesSessaoComponent,
    RealizarSessaoComponent
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
