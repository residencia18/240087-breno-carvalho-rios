import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  constructor(private http: HttpClient) {}

  getCountry() {
    return this.http.get('https://restcountries.com/v3.1/all');
  }

  countryToJson(country: any): any {
    return Object.keys(country).map((key) => {
      return country[key] = {
        tipo: 'text',
        nome: key,
        rotulo: key,
      }
    })
  }
}
