import { Routes } from '@angular/router';
import { countriesResolver } from './resolvers/countries.resolver';
import { CountriesListComponent } from './components/countries/countries-list/countries-list.component';

export const routes: Routes = [
    {
        path: '',
        component: CountriesListComponent,
        resolve: {
            countries:countriesResolver
        }
    }
];
