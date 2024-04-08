import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { CountriesListComponent } from './components/countries/countries-list/countries-list.component';
import { CountryService } from './services/countries.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, CountriesListComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private countriesService: CountryService) {}
  loadingTime = this.countriesService.loadingTime;
  title = 'Exercicio01';
}
