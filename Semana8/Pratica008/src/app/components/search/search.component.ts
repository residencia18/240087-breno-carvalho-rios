import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ArticlesService } from '../../services/articles.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {
  query = '';
  value = '';
  rows = 10;
  articles: any[] = [];
  @Output() onLoadArticles: EventEmitter<{ rows: number, articles: any[] }> = new EventEmitter();
  constructor(private articlesService: ArticlesService) { }
  getArticles(search: string) {
    this.query = search;
    if (search === '') {
      this.articles = [];
      this.onLoadArticles.emit({ rows: this.rows, articles: this.articles });
      return;
    }

    this.articlesService.getArticles(search).subscribe((articles) => {
      this.articles = articles.query.search.map((article: any) => {
        return { title: article.title, content: article.snippet, url: `https://en.wikipedia.org/wiki/${article.title}` };
      });
      this.onLoadArticles.emit({ rows: this.rows, articles: this.articles });
    });
  }
}
