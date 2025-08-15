import { Routes } from '@angular/router';
import { canLoginGuard } from './Core/guards/canLoginGuard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'LogIn',
    pathMatch: 'full',
  },
  {
    path: '',
    loadChildren: () =>
      import('./Features/Auth/Components/login/login.routes').then(
        (m) => m.routes
      ),
  },
  {
    path: '',
    loadChildren: () =>
      import(
        './Features/Auth/Components/registration/registration.routes'
      ).then((m) => m.routes),
  },
  {
    path: '',
    loadChildren: () =>
      import('./Features/Home/Components/home/home.routes').then(
        (m) => m.routes
      ),
    canActivate: [canLoginGuard],
  },
];
