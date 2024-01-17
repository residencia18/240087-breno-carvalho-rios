import { Component } from '@angular/core';
import { CountriesService } from './services/countries.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Aula';
  countries: any[] = [];

  constructor(private countriesService: CountriesService){}

  ngOnInit(){
    this.getCountries();
  }

  getCountries() {
    this.countriesService.getCountries().subscribe((data) => {
      this.countries = data.map((country: any) => {
        return { name: country.translations.por.official, population: country.population }
      }).sort((a: any, b: any) => b.population - a.population);
    });
  }
}
