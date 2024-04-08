import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private delayTime = 5;
  public loadingTime: number = this.delayTime;
  constructor(private http: HttpClient) {}

  getCountries() {
    let startFrom = new Date().getTime();
    return this.http.get('https://restcountries.com/v3.1/all').pipe(
      tap(() => { this.loadingTime += new Date().getTime() - startFrom}),
      delay(this.delayTime * 1000),
    );
  }
}