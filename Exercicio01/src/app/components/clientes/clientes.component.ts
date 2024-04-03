import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [CommonModule, TableModule],
  templateUrl: './clientes.component.html',
  styleUrl: './clientes.component.css',
})
export class ClientesComponent {
  clientes = [
    { nome: 'Cliente 1', cpf: '123.456.789-00', email: 'cliente1@example.com', dataNascimento: new Date('1990-01-01') },
    { nome: 'Cliente 2', cpf: '234.567.890-11', email: 'cliente2@example.com', dataNascimento: new Date('1991-02-02') },
    { nome: 'Cliente 3', cpf: '345.678.901-22', email: 'cliente3@example.com', dataNascimento: new Date('1992-03-03') }
  ];
}
