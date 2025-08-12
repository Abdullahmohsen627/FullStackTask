import { Routes } from '@angular/router';
import { canLoginGuard } from '../../Core/guards/canLoginGuard';
import { Login } from './login';

export const routes: Routes = [
  { path: 'Home', component: Login, canActivate: [canLoginGuard] },
];
