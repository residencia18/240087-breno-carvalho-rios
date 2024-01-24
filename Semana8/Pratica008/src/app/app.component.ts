import { Component } from '@angular/core';
import { ArticlesService } from './services/articles.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Pratica008';
  value: string = '';
  query: string = '';
  articles: any[] = [];
  rows: number = 0;

  constructor(private articlesService: ArticlesService) { }

  getArticles(data: any) {
    this.articles = data.articles;
    this.rows = data.rows;
  }
}
