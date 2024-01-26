import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-wikipedia-articles-list',
  templateUrl: './wikipedia-articles-list.component.html',
  styleUrl: './wikipedia-articles-list.component.css'
})
export class WikipediaArticlesListComponent {
  @Input() articles: any[] = [];
  @Input() rows: number = 0;
}
