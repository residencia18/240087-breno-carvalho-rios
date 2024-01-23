import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ArticlesService } from '../../services/articles.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {
  limit = 10;
  query = '';
  value = '';
  articles: any[] = [];
  @Output() onLoadArticles: EventEmitter<any[]> = new EventEmitter();
  constructor(private articlesService: ArticlesService) { }
  getArticles(search: string, limit: number) {
    this.query = search;
    this.articlesService.getArticles(search, limit).subscribe((articles) => {
      this.articles = articles.query.search.map((article: any) => {
        return { title: article.title, content: article.snippet, url: `https://en.wikipedia.org/wiki/${article.title}` };
      });
      this.onLoadArticles.emit(this.articles);
    });
  }
}
