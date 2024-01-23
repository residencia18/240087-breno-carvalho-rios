import { Component } from '@angular/core';
import { ArticlesService } from './services/articles.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Pratica008';
  limit: number = 10;
  loading: boolean = true;
  message: string = "Faça uma busca";
  value: string = '';
  query: string = '';
  articles: any[] = [];

  constructor(private articlesService: ArticlesService) { }

  ngOnInit() {
    // this.getArticles('Universidade Estadual de Santa Cruz', 10);
  }

  getArticles(articles: any[]) {
    this.message = "Carregando..."
    this.loading = true;
    this.articles = articles;
  }

  // getArticles(search: string, limit: number) {
  //   this.message = "Carregando..."
  //   this.loading = true;
  //   this.query = search;
  //   this.articlesService.getArticles(search, limit).subscribe((articles) => {
  //     console.log(articles);
  //     this.loading = false;
  //     this.articles = articles.query.search.map((article: any) => {
  //       return { title: article.title, content: article.snippet, url: `https://en.wikipedia.org/wiki/${article.title}` };
  //     });
  //   });
  // }
}
