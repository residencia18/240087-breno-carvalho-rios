import { Component, OnInit } from '@angular/core';
import { NoticiasService } from '../api-services/noticias.service';
import { Noticia, NoticiasResponse } from '../models/noticia';
@Component({
  selector: 'app-noticias',
  templateUrl: './noticias.component.html',
  styleUrl: './noticias.component.css'
})
export class NoticiasComponent implements OnInit {
  noticia = {} as Noticia;
  noticias!: Noticia[];

  constructor(private noticiasService: NoticiasService) {}
  
  ngOnInit() {
    this.getNoticias();
  }
  getNoticias() {
    this.noticiasService.getNoticias().subscribe((noticias: NoticiasResponse) => {
      this.noticias = noticias.news;
    });
  }
}
