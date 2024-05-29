import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { UserListComponent } from './admin/user-list/user-list.component';
import { MainComponent } from './common/main/main.component';
import { UserFilesComponent as AdminUserFilesComponent } from './admin/user-files/user-files.component';
import { UserFilesComponent } from './user/user-files/user-files.component';
import { AuthGuard, redirectUnauthorizedTo } from '@angular/fire/auth-guard';
import { UserProfileComponent } from './user/user-profile/user-profile.component';
import { HelpComponent } from './others/help/help.component';

const redirectUnauthorizedToLogin = () => redirectUnauthorizedTo(['auth/login']);

export const routes: Routes = [
    {
        path: 'auth', children: [
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'login', pathMatch: 'full' },
        ]
    },
    {
        path: '', canActivate: [AuthGuard], data: { authGuardPipe: redirectUnauthorizedToLogin }, component: MainComponent, children: [
            {
                path: 'admin', children: [
                    { path: 'users/:id/files', component: AdminUserFilesComponent },
                    { path: 'users', component: UserListComponent },
                    { path: '**', redirectTo: 'users', pathMatch: 'full' }
                ]
            },
            {
                path: 'me', children: [
                    { path: 'profile', component: UserProfileComponent },
                    { path: 'files', component: UserFilesComponent },
                    { path: '**', redirectTo: 'files', pathMatch: 'full' }
                ]
            },
            { path: 'help', component: HelpComponent },
            { path: '**', redirectTo: 'me', pathMatch: 'full' },
        ]
    },
    { path: '**', redirectTo: 'auth', pathMatch: 'full' }
];
