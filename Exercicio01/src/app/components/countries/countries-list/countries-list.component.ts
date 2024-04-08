import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-countries-list',
  standalone: true,
  imports: [TableModule],
  templateUrl: './countries-list.component.html',
  styleUrl: './countries-list.component.css'
})
export class CountriesListComponent {
  countries: any = [];
  loadingTime: number = 0;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(){
    this.countries = this.route.snapshot.data['countries'];
  }
}
