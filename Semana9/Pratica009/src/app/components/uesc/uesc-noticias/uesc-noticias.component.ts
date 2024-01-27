import { Component } from '@angular/core';
import { UescNoticiasService } from '../../../services/uesc/uesc-noticias.service';

@Component({
  selector: 'app-uesc-noticias',
  templateUrl: './uesc-noticias.component.html',
  styleUrl: './uesc-noticias.component.css'
})
export class UescNoticiasComponent {
  noticias: any[] = [];

  constructor(private noticiasService: UescNoticiasService) { }

  ngOnInit() {
    this.getNoticias();
  }
  getNoticias() {
    this.noticiasService.getNoticias().subscribe((noticias: any) => {
      this.noticias = noticias.news.slice(0, 5);
    });
  }
}
