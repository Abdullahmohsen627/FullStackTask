import { Routes } from '@angular/router';
import { canLoginGuard } from '../../Core/guards/canLoginGuard';
import { Home } from './home';

export const routes: Routes = [
  { path: 'Home', component: Home, canActivate: [canLoginGuard] },
];
