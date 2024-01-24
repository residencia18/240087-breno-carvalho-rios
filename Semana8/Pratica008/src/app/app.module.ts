import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DataViewModule } from 'primeng/dataview';

import { SearchComponent } from './components/search/search.component';
import { ArticlesListComponent } from './components/articles-list/articles-list.component';
import { WikipediaSpanToStrongPipe } from './pipes/wikipedia-span-to-strong.pipe';
import { CeilPipe } from './pipes/ceil.pipe';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    ArticlesListComponent,
    CeilPipe,
    WikipediaSpanToStrongPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    InputTextModule,
    ButtonModule,
    CardModule,
    DataViewModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
