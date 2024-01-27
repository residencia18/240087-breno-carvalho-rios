import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UescServicosService {
  private CURRENCY_API_KEY = "fca_live_mfcnOEpOKcv0bCuc6HpoHishYO7b7ntjUWI7ZhLH";
  private WEATHER_API_KEY = "7d3187cad8f844b0ba805450231012";
  private currencyUrl = `https://api.freecurrencyapi.com/v1/latest?apikey=${this.CURRENCY_API_KEY}&currencies=USD%2CEUR&base_currency=BRL`;
  private uescWeatherUrl = `https://api.weatherapi.com/v1/current.json?key=${this.WEATHER_API_KEY}&q=-14.7980073,-39.1763752&aqi=no&lang=pt`;

  constructor(private http: HttpClient) { }

  getCurrency(): Observable<any> {
    const params = new HttpParams().set('origin', '*');
    return this.http.get(this.currencyUrl, { params });
  }

  getUescWeather(): Observable<any> {
    const params = new HttpParams().set('origin', '*');
    return this.http.get(this.uescWeatherUrl, { params });
  }
}
