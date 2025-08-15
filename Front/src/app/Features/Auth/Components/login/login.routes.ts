import { Routes } from '@angular/router';
import { authGuard } from '../../../../Core/guards/authGuard';
import { Login } from './login';

export const routes: Routes = [
  { path: 'LogIn', component: Login, canActivate: [authGuard] },
];
