import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-file-list',
  standalone: true,
  imports: [CommonModule, RouterModule, TableModule, ButtonModule],
  templateUrl: './file-list.component.html',
  styleUrl: './file-list.component.css'
})
export class FileListComponent {
  private _files = [
    { id: 1, name: "File 1", url: "https://www.google.com", createdAt: "18/05/2024" },
    { id: 2, name: "File 2", url: "https://www.google.com", createdAt: "18/05/2024" },
    { id: 3, name: "File 3", url: "https://www.google.com", createdAt: "18/05/2024" },
    { id: 4, name: "File 4", url: "https://www.google.com", createdAt: "18/05/2024" },
    { id: 5, name: "File 5", url: "https://www.google.com", createdAt: "18/05/2024" },
    { id: 6, name: "File 6", url: "https://www.google.com", createdAt: "18/05/2024" },
    { id: 7, name: "File 7", url: "https://www.google.com", createdAt: "18/05/2024" },
  ];

  public files = this._files;
}
