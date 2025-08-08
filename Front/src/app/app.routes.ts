import { Routes } from '@angular/router';
import { SignUp } from './Components/Registration/sign-up/sign-up';
import { Login } from './Components/login/login';
import { Home } from './Components/home/home';
import { ValidateOTP } from './Components/Registration/validate-otp/validate-otp';
import { SetPassword } from './Components/Registration/set-password/set-password';
import { canLoginGuard } from './can-login-guard';

export const routes: Routes = [
  { path: 'LogIn', component: Login },
  { path: 'SetPas', component: SetPassword },
  { path: 'Register', component: SignUp },
  { path: 'OTPValidation', component: ValidateOTP },
  { path: 'Home', component: Home, canActivate: [canLoginGuard] },
  { path: '', redirectTo: 'LogIn', pathMatch: 'full' },
];
