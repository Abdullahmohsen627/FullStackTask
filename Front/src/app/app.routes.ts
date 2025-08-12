import { Routes } from '@angular/router';
import { SignUp } from './Components/registration/signUp/signUp';
import { Login } from './Components/login/login';
import { Home } from './Components/home/home';
import { ValidateOTP } from './Components/registration/validateOtp/validateOtp';
import { SetPassword } from './Components/registration/setPassword/setPassword';
import { canLoginGuard } from './Core/guards/canLoginGuard';
import { authGuard } from './Core/guards/authGuard';

export const routes: Routes = [
  {
    path: 'LogIn',
    loadComponent: () =>
      import('./Components/login/login').then((m) => m.Login),
  },
  {
    path: 'SetPas',
    loadComponent: () =>
      import('./Components/registration/setPassword/setPassword').then(
        (m) => m.SetPassword
      ),
  },
  {
    path: 'Register',
    loadComponent: () =>
      import('./Components/registration/signUp/signUp').then((m) => m.SignUp),
  },
  {
    path: 'OTPValidation',
    loadComponent: () =>
      import('./Components/registration/validateOtp/validateOtp').then(
        (m) => m.ValidateOTP
      ),
  },
  {
    path: 'Home',
    loadComponent: () => import('./Components/home/home').then((m) => m.Home),
    canActivate: [canLoginGuard],
  },
  {
    path: '',
    redirectTo: 'LogIn',
    pathMatch: 'full',
  },
];
