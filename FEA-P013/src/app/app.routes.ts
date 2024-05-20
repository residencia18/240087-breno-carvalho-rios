import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { UserListComponent } from './admin/user-list/user-list.component';
import { MainComponent } from './common/main/main.component';
import { FileListComponent } from './admin/file-list/file-list.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
    {
        path: 'auth', children: [
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'login', pathMatch: 'full' },
        ]
    },
    {
        path: '', canActivate: [authGuard], component: MainComponent, children: [
            {
                path: 'admin', children: [
                    { path: 'users', component: UserListComponent },
                    { path: 'users/:id/files', component: FileListComponent },
                    { path: '**', redirectTo: 'users', pathMatch: 'full' }
                ]
            },
            { path: '**', redirectTo: 'admin', pathMatch: 'full' },
        ]
    },
    { path: '**', redirectTo: 'auth/login', pathMatch: 'full' }
];
