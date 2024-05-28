import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { UserListComponent } from './admin/user-list/user-list.component';
import { MainComponent } from './common/main/main.component';
import { authGuard } from './guards/auth.guard';
import { UserFilesComponent as AdminUserFilesComponent } from './admin/user-files/user-files.component';
import { UserFilesComponent } from './user/user-files/user-files.component';

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
                    { path: 'users/:id/files', component: AdminUserFilesComponent },
                    { path: 'users', component: UserListComponent },
                    { path: '**', redirectTo: 'users', pathMatch: 'full' }
                ]
            },
            {
                path: 'me', children: [
                    { path: 'files', component: UserFilesComponent },
                    { path: '**', redirectTo: '../', pathMatch: 'full' }
                ]
            },
            { path: '**', redirectTo: 'me', pathMatch: 'full' },
        ]
    },
    { path: '**', redirectTo: 'auth/login', pathMatch: 'full' }
];
