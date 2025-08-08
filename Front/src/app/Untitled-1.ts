import { Routes } from '@angular/router';
import { SignUp } from './Components/Registration/sign-up/sign-up';
import { Login } from './Components/login/login';
import { Home } from './Components/home/home';
import { ValidateOTP } from './Components/Registration/validate-otp/validate-otp';
import { SetPassword } from './Components/Registration/set-password/set-password';
import { canLoginGuard } from './can-login-guard';

export const routes: Routes = [
  {
    path: 'LogIn',
    loadComponent: () =>
      import('./Components/login/login').then((m) => m.Login),
  },
  {
    path: 'SetPas',
    loadComponent: () =>
      import('./Components/Registration/set-password/set-password').then(
        (m) => m.SetPassword
      ),
  },
  {
    path: 'Register',
    loadComponent: () =>
      import('./Components/Registration/sign-up/sign-up').then((m) => m.SignUp),
  },
  {
    path: 'OTPValidation',
    loadComponent: () =>
      import('./Components/Registration/validate-otp/validate-otp').then(
        (m) => m.ValidateOTP
      ),
  },
  { path: 'Home', component: Home },
  { path: '', redirectTo: 'LogIn', pathMatch: 'full' },
];
