import { Component } from '@angular/core';
import { UescResultadosService } from '../../../services/uesc/uesc-resultados.service';

@Component({
  selector: 'app-uesc-resultados',
  templateUrl: './uesc-resultados.component.html',
  styleUrl: './uesc-resultados.component.css'
})
export class UescResultadosComponent {
  lang: string = 'portuguese';
  pais: any = {};
  results: any[] = [];

  constructor(private resultsService: UescResultadosService) { }

  ngOnInit() {
    this.getResults();
  }
  getResults() {
    this.resultsService.getResults(this.lang).subscribe((results: any[]) => {
      this.results = results;
      this.results.sort((a, b) => a.translations.por.official.localeCompare(b.translations.por.official));
    });
  }
}
