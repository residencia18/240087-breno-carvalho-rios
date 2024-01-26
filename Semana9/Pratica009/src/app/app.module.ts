import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { TabMenuModule } from 'primeng/tabmenu';
import { TurismoMainComponent } from './components/turismo/turismo-main/turismo-main.component';
import { TurismoCardComponent } from './components/turismo/turismo-card/turismo-card.component';

@NgModule({
  declarations: [
    AppComponent,
    TurismoMainComponent,
    TurismoCardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    TabMenuModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
