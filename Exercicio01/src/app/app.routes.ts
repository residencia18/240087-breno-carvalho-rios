import { Routes } from '@angular/router';
import { ProdutosComponent } from './components/produtos/produtos.component';

export const routes: Routes = [
    { path: '', redirectTo: 'produtos', pathMatch: 'full' },
    { path: 'produtos', component: ProdutosComponent },
    { path: 'clientes', loadComponent: () => import('./components/clientes/clientes.component').then(m => m.ClientesComponent) },
    { path: 'fornecedores', loadComponent: () => import('./components/fornecedores/fornecedores.component').then(m => m.FornecedoresComponent) },
];
