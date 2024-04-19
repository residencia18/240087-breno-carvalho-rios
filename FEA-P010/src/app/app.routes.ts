import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./components/items-list/items-list.component').then(c => c.ItemsListComponent)
    },
    {
        path: 'carrinho',
        loadComponent: () => import('./components/cart/cart.component').then(c => c.CartComponent)
    }
];
