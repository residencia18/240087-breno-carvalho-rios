import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, from, throwError } from 'rxjs';
import { retry, catchError, switchMap } from 'rxjs/operators';
import { CurrenciesResponse, WeatherResponse } from '../models/service';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  private CURRENCY_API_KEY = "fca_live_mfcnOEpOKcv0bCuc6HpoHishYO7b7ntjUWI7ZhLH";
  private WEATHER_API_KEY = "7d3187cad8f844b0ba805450231012";
  private currencyUrl = `https://api.freecurrencyapi.com/v1/latest?apikey=${this.CURRENCY_API_KEY}&currencies=USD%2CEUR&base_currency=BRL`;
  
  constructor(private httpClient: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  getCurrency(): Observable<CurrenciesResponse> {
    return this.httpClient.get<CurrenciesResponse>(this.currencyUrl)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getUescWeather(): Observable<WeatherResponse> {
    let uescWeatherUrl = `https://api.weatherapi.com/v1/current.json?key=${this.WEATHER_API_KEY}&q=-14.7980073,-39.1763752&aqi=no&lang=pt`;
    return this.httpClient.get<WeatherResponse>(uescWeatherUrl)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getWeather(): Observable<WeatherResponse> {
    return from(this.getGeolocation()).pipe(
      switchMap((coords: any) => {
        let weatherUrl = `https://api.weatherapi.com/v1/current.json?key=${this.WEATHER_API_KEY}&q=${coords.lat},${coords.lon}&aqi=no&lang=pt`;
  
        return this.httpClient.get<WeatherResponse>(weatherUrl).pipe(
          retry(2),
          catchError(this.handleError)
        );
      })
    );
  }
  
  getGeolocation(): Promise<any> {
    return new Promise((resolve, reject) => {
      if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
          (position) => {
            resolve({
              lat: position.coords.latitude,
              lon: position.coords.longitude
            });
          },
          (error) => {
            reject(error);
          }
        );
      } else {
        reject(new Error("Seu navegador não suporta geolocalização"));
      }
    });
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
