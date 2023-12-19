import { Component, OnInit } from '@angular/core';
import { Result } from '../models/result';
import { ResultsService } from '../api-services/results.service';

@Component({
  selector: 'app-resultados',
  templateUrl: './resultados.component.html',
  styleUrl: './resultados.component.css'
})
export class ResultadosComponent implements OnInit {
  lang = 'portuguese';
  pais = {} as Result;
  results = [] as Result[];

  constructor(private resultsService: ResultsService) {}
  
  ngOnInit() {
    this.getResults();
  }
  getResults() {
    this.resultsService.getResults(this.lang).subscribe((results: Result[]) => {
      this.results = results;
      this.results.sort((a, b) => a.translations.por.official.localeCompare(b.translations.por.official));
    });
  }
}
