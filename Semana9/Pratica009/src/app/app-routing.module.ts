import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TurismoMainComponent } from './components/turismo/turismo-main/turismo-main.component';
import { WikipediaMainComponent } from './components/wikipedia/wikipedia-main/wikipedia-main.component';
import { UescMainComponent } from './components/uesc/uesc-main/uesc-main.component';

const routes: Routes = [
  { path: 'turismo', component: TurismoMainComponent },
  { path: 'uesc', component: UescMainComponent },
  { path: 'wikipedia', component: WikipediaMainComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
