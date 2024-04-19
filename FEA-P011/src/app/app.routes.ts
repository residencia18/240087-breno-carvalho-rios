import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./input-tarefa/input-tarefa.component').then(c => c.InputTarefaComponent)
    },
    {
        path: 'update/:id',
        loadComponent: () => import('./update-tarefa/update-tarefa.component').then(c => c.UpdateTarefaComponent)
    }
];
