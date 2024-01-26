import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TurismoMainComponent } from './components/turismo/turismo-main/turismo-main.component';

const routes: Routes = [
  { path: 'turismo', component: TurismoMainComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
