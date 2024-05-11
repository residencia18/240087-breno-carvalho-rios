import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./input-tarefa/input-tarefa.component').then(c => c.InputTarefaComponent)
    }
];
