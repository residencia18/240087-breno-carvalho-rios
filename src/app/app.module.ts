import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { AuthModule } from './modules/auth/auth.module';
import { SharedModule } from './modules/shared/shared.module';
import { SuinoModule } from './modules/suino/suino.module';
import { PesoModule } from './modules/peso/peso.module';
import { SessaoModule } from './modules/sessao/sessao.module';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';


registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,

    SharedModule,
    AuthModule,
    SuinoModule,
    PesoModule,
    SessaoModule,
    ButtonModule,
    MenubarModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: LOCALE_ID, useValue: 'pt-BR' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
