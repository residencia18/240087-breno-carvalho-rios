import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { TabMenuModule } from 'primeng/tabmenu';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DataViewModule } from 'primeng/dataview';

import { TurismoMainComponent } from './components/turismo/turismo-main/turismo-main.component';
import { TurismoCardComponent } from './components/turismo/turismo-card/turismo-card.component';
import { WikipediaMainComponent } from './components/wikipedia/wikipedia-main/wikipedia-main.component';
import { WikipediaArticlesListComponent } from './components/wikipedia/wikipedia-articles-list/wikipedia-articles-list.component';
import { WikipediaSearchComponent } from './components/wikipedia/wikipedia-search/wikipedia-search.component';
import { WikipediaSpanToStrongPipe } from './pipes/wikipedia/wikipedia-span-to-strong.pipe';
import { CeilPipe } from './pipes/common/ceil.pipe';
import { UescMainComponent } from './components/uesc/uesc-main/uesc-main.component';

@NgModule({
  declarations: [
    AppComponent,
    TurismoMainComponent,
    TurismoCardComponent,
    WikipediaMainComponent,
    WikipediaArticlesListComponent,
    WikipediaSearchComponent,
    WikipediaSpanToStrongPipe,
    CeilPipe,
    UescMainComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    TabMenuModule,
    InputTextModule,
    ButtonModule,
    CardModule,
    DataViewModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
