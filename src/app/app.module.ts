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
import { AuthModule } from './modules/auth/auth.module';
import { SharedModule } from './modules/shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddSuinoComponent } from './modules/suino/components/add-suino/add-suino.component';
import { ListaSuinosComponent } from './modules/suino/components/lista-suinos/lista-suinos.component';
import { CardSuinoComponent } from './modules/suino/components/card-suino/card-suino.component';
import { DetalhesSuinoComponent } from './modules/suino/components/detalhes-suino/detalhes-suino.component';
import { CardPesoComponent } from './modules/suino/components/card-peso/card-peso.component';
import { AddSessaoComponent } from './modules/sessao/components/add-sessao/add-sessao.component';
import { DetalhesSessaoComponent } from './modules/sessao/components/detalhes-sessao/detalhes-sessao.component';
import { ListaSessoesComponent } from './modules/sessao/components/lista-sessoes/lista-sessoes.component';
import { RealizarSessaoComponent } from './modules/sessao/components/realizar-sessao/realizar-sessao.component';
import { AddPesoComponent } from './modules/peso/components/add-peso/add-peso.component';
import { CardSessaoComponent } from './modules/sessao/components/card-sessao/card-sessao.component';


registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    AddSuinoComponent,
    ListaSuinosComponent,
    CardSuinoComponent,
    DetalhesSuinoComponent,
    CardPesoComponent,
    AddSessaoComponent,
    DetalhesSessaoComponent,
    ListaSessoesComponent,
    RealizarSessaoComponent,
    AddPesoComponent,
    CardSessaoComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,

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
