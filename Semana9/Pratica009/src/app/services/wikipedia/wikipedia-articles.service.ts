import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WikipediaArticlesService {
  private limit = 100;
  public articles: any[] = [];

  constructor(private http: HttpClient) { }

  getArticles(search: string): Observable<any> {
    const apiUrl = `https://en.wikipedia.org/w/api.php`;
    const params = new HttpParams()
      .set('action', 'query')
      .set('format', 'json')
      .set('list', 'search')
      .set('formatversion', '2')
      .set('srlimit', this.limit.toString())
      .set('srsearch', search)
      .set('origin', '*');

    return this.http.get(apiUrl, { params });
  }
}
