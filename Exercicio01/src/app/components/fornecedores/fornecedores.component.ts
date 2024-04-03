import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-fornecedores',
  standalone: true,
  imports: [CommonModule, TableModule],
  templateUrl: './fornecedores.component.html',
  styleUrl: './fornecedores.component.css'
})
export class FornecedoresComponent {
  fornecedores = [
    { nome: 'Fornecedor 1', endereco: 'Rua 1, 123', telefone: '(11) 1234-5678', email: 'f1@example.com' },
    { nome: 'Fornecedor 2', endereco: 'Avenida X, 456', telefone: '(22) 2345-6789', email: 'f2@example.com' },
    { nome: 'Fornecedor 3', endereco: 'Travessa Y, 789', telefone: '(33) 3456-7890', email: 'f3@example.com' }
  ];
}
