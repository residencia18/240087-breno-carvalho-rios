import { Component } from '@angular/core';
import { destination } from '../types/turismo.types';

@Component({
  selector: 'app-turismo-main',
  templateUrl: './turismo-main.component.html',
  styleUrl: './turismo-main.component.css'
})
export class TurismoMainComponent {
  destinationList: destination[] = [
    {
      image: {
        url: 'assets/turismo/images/salvador.jpg',
        alt: 'Imagem Salvador'
      },
      name: 'Salvador',
      details: [
        'Aéreo',
        '03 diárias',
        'Café da Manhã'
      ],
      price: {
        value: 670.00,
        details: [
          'Taxas Inclusas',
          'Em até 10x sem Juros'
        ]
      },
    },
    {
      image: {
        url: 'assets/turismo/images/fortaleza.jpg',
        alt: 'Imagem Fortaleza'
      },
      name: 'Fortaleza',
      details: [
        'Aéreo ida e volta',
        '06 diárias',
        'Café da Manhã'
      ],
      price: {
        value: 1513.00,
        details: [
          'Taxas Inclusas',
          'Em até 10x sem Juros'
        ]
      },
    },
    {
      image: {
        url: 'assets/turismo/images/campinas.jpg',
        alt: 'Imagem Campinas'
      },
      name: 'Campinas',
      details: [
        'Aéreo ida e volta',
        '04 diárias',
        'Café da Manhã'
      ],
      price: {
        value: 900.00,
        details: [
          'Taxas Inclusas',
          'Em até 10x sem Juros'
        ]
      },
    }
  ]
}
