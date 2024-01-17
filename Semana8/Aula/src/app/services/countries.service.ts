import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CountriesService {
  public countries: any[] = [];

  constructor(private http: HttpClient) { }
  
  getCountries(): Observable<any> {
    return this.http.get('https://restcountries.com/v3.1/all');
  }
}
