import { Component } from '@angular/core';
import { WikipediaArticlesService } from '../../../services/wikipedia/wikipedia-articles.service';

@Component({
  selector: 'app-wikipedia-main',
  templateUrl: './wikipedia-main.component.html',
  styleUrl: './wikipedia-main.component.css'
})
export class WikipediaMainComponent {
  value: string = '';
  query: string = '';
  articles: any[] = [];
  rows: number = 0;

  constructor() { }

  getArticles(data: any) {
    this.articles = data.articles;
    this.rows = data.rows;
  }
}
