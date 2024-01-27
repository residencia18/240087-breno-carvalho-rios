import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UescResultadosService {
  private NEWS_API_KEY = "iaXOUw6l6solSkhKgY9ygTf3vZyT6cRvcbiG5RTa_MMmBF4A";

  constructor(private http: HttpClient) { }

  getResults(lang: string): Observable<any> {
    const apiUrl = `https://restcountries.com/v3.1/lang/${lang}`;
    const params = new HttpParams().set('origin', '*');
    return this.http.get(apiUrl, { params });
  }
}
