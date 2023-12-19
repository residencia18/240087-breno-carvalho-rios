import { Component, OnInit } from '@angular/core';
import { CurrenciesResponse, WeatherResponse } from '../models/service';
import { ServicesService } from '../api-services/services.service';

@Component({
  selector: 'app-servicos',
  templateUrl: './servicos.component.html',
  styleUrl: './servicos.component.css'
})
export class ServicosComponent implements OnInit {
  weather = {} as WeatherResponse;
  uescWeather = {} as WeatherResponse;
  currencies = {} as CurrenciesResponse;

  constructor(private servicesService: ServicesService) {}
  
  ngOnInit() {
    this.getWeather();
    this.getUescWeather();
    this.getCurrencies();
  }

  async getWeather() {
    this.servicesService.getWeather().subscribe((weather: WeatherResponse) => {
      this.weather = weather;
      let dateTime = {
        date: weather.current.last_updated.split(' ')[0].split('-').reverse().join('/'),
        time: weather.current.last_updated.split(' ')[1]
      }
      this.weather.current.last_updated = dateTime.date + ' ' + dateTime.time;
    });
  }

  getUescWeather() {
    this.servicesService.getUescWeather().subscribe((weather: WeatherResponse) => {
      this.uescWeather = weather;
      let dateTime = {
        date: weather.current.last_updated.split(' ')[0].split('-').reverse().join('/'),
        time: weather.current.last_updated.split(' ')[1]
      }
      this.uescWeather.current.last_updated = dateTime.date + ' ' + dateTime.time;
    });
  }

  getCurrencies() {
    this.servicesService.getCurrency().subscribe((currencies: CurrenciesResponse) => {
      this.currencies = currencies;
      this.currencies.data['USD'] = (1 / parseFloat(currencies.data['USD'])).toFixed(2);
      this.currencies.data['EUR'] = (1 / parseFloat(currencies.data['EUR'])).toFixed(2);
    });
  }
}
