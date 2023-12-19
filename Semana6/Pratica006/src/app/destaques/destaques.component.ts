import { Component, OnInit } from '@angular/core';
import { Highlight } from '../models/highlights';
import { HighlightsService } from '../api-services/highlights.service';

@Component({
  selector: 'app-destaques',
  templateUrl: './destaques.component.html',
  styleUrl: './destaques.component.css'
})
export class DestaquesComponent implements OnInit {
  highlight = {} as Highlight;

  constructor(private highlightService: HighlightsService) {}
  
  ngOnInit() {
    this.getDestaques();
  }
  getDestaques() {
    this.highlightService.getHighlights().subscribe((highlight: Highlight) => {
      this.highlight = highlight;
      if(highlight.media_type != 'image') {
        this.highlight.url = highlight.thumbnail_url;
      }
    });
  }
}
