import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-produtos',
  standalone: true,
  imports: [CommonModule, TableModule],
  templateUrl: './produtos.component.html',
  styleUrl: './produtos.component.css'
})
export class ProdutosComponent {

  produtos: any[] = [
    { nome: 'Produto 1', descricao: 'Descricao do produto 1', preco: 10.99 },
    { nome: 'Produto 2', descricao: 'Descricao do produto 2', preco: 20.99 },
    { nome: 'Produto 3', descricao: 'Descricao do produto 3', preco: 30.99 },
    { nome: 'Produto 4', descricao: 'Descricao do produto 4', preco: 40.99 },
    { nome: 'Produto 5', descricao: 'Descricao do produto 5', preco: 50.99 }
  ];

}
