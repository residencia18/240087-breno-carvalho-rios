import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  private limit = 100;
  public articles: any[] = [];

  constructor(private http: HttpClient) { }

  getArticles(search: string): Observable<any> {
    const apiUrl = `/api.php?action=query&format=json&list=search&utf8=1&formatversion=2&srsearch=${search}&srlimit=${this.limit}`;
    return this.http.get(apiUrl);
  }
}
