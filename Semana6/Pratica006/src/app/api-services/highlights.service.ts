import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Highlight, HilightsResponse } from '../models/highlights';

@Injectable({
  providedIn: 'root'
})
export class HighlightsService {
  private NASA_API_KEY = 'BRlZpq9k7zNO4SiegO3rhHudfmMJhMiTcXaKgxcQ';
  private yesterday: Date;
  private url: string;
  
  constructor(private httpClient: HttpClient) {
    this.yesterday = new Date();
    this.yesterday.setDate(this.yesterday.getDate());
    // this.url = `https://api.nasa.gov/planetary/apod?api_key=${this.NASA_API_KEY}&thumbs=true&start_date=${this.yesterday.toISOString().slice(0, 10)}`;
    this.url = `https://api.nasa.gov/planetary/apod?api_key=${this.NASA_API_KEY}`;
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  getHighlights(): Observable<Highlight> {
    return this.httpClient.get<Highlight>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
