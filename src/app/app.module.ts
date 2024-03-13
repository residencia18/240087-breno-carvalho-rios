import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
import { AccordionModule } from 'primeng/accordion';

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
import { AddEventoComponent } from './components/evento-components/add-evento/add-evento.component';
import { ListaEventosComponent } from './components/evento-components/lista-eventos/lista-eventos.component';


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
    AddEventoComponent,
    ListaEventosComponent
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
    AccordionModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
