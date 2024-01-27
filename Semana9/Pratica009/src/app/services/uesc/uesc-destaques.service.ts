import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UescDestaquesService {
  private NASA_API_KEY = 'BRlZpq9k7zNO4SiegO3rhHudfmMJhMiTcXaKgxcQ';
  private yesterday: Date;
  private apiUrl: string;

  constructor(private http: HttpClient) {
    this.yesterday = new Date();
    this.yesterday.setDate(this.yesterday.getDate());
    this.apiUrl = `https://api.nasa.gov/planetary/apod?api_key=${this.NASA_API_KEY}`;
  }

  getDestaques(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
