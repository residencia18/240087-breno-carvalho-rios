import { Component } from '@angular/core';
import { UescDestaquesService } from '../../../services/uesc/uesc-destaques.service';

@Component({
  selector: 'app-uesc-destaques',
  templateUrl: './uesc-destaques.component.html',
  styleUrl: './uesc-destaques.component.css'
})
export class UescDestaquesComponent {
  destaque: any = {};

  constructor(private destaquesService: UescDestaquesService) { }

  ngOnInit() {
    this.getDestaques();
  }
  getDestaques() {
    this.destaquesService.getDestaques().subscribe((destaque: any) => {
      this.destaque = destaque;
      if (destaque.media_type != 'image') {
        this.destaque.url = destaque.thumbnail_url;
      }
    });
  }
}
