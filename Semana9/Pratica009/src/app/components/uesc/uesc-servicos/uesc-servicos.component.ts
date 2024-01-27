import { Component } from '@angular/core';
import { UescServicosService } from '../../../services/uesc/uesc-servicos.service';

@Component({
  selector: 'app-uesc-servicos',
  templateUrl: './uesc-servicos.component.html',
  styleUrl: './uesc-servicos.component.css'
})
export class UescServicosComponent {
  weather: any = {};
  uescWeather: any = {};
  currencies: any = {};

  constructor(private servicosService: UescServicosService) { }

  ngOnInit() {
    this.getUescWeather();
    this.getCurrencies();
  }

  getUescWeather() {
    this.servicosService.getUescWeather().subscribe((weather: any) => {
      this.uescWeather = weather;
      let dateTime = {
        date: weather.current.last_updated.split(' ')[0].split('-').reverse().join('/'),
        time: weather.current.last_updated.split(' ')[1]
      }
      this.uescWeather.current.last_updated = dateTime.date + ' ' + dateTime.time;
    });
  }

  getCurrencies() {
    this.servicosService.getCurrency().subscribe((currencies: any) => {
      this.currencies = currencies;
      this.currencies.data['USD'] = (1 / parseFloat(currencies.data['USD'])).toFixed(2);
      this.currencies.data['EUR'] = (1 / parseFloat(currencies.data['EUR'])).toFixed(2);
    });
  }
}
