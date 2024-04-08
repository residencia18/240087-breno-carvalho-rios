import { ResolveFn } from '@angular/router';
import { CountryService } from '../services/countries.service';
import { inject } from '@angular/core';
import { Observable } from 'rxjs';

export const countriesResolver: ResolveFn<Observable<any>> = (route, state) => {
  const countriesService = inject(CountryService);
  return countriesService.getCountries();
};
