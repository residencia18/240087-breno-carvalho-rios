import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UescNoticiasService {
  private NEWS_API_KEY = "iaXOUw6l6solSkhKgY9ygTf3vZyT6cRvcbiG5RTa_MMmBF4A";
  private apiUrl = `https://api.currentsapi.services/v1/latest-news?apiKey=${this.NEWS_API_KEY}&category=academia`;

  constructor(private http: HttpClient) { }

  getNoticias(): Observable<any> {
    const params = new HttpParams().set('origin', '*');
    return this.http.get(this.apiUrl, { params });
  }
}
