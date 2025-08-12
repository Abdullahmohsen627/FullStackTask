import { Routes } from '@angular/router';
import { SetPassword } from './setPassword/setPassword';
import { canLoginGuard } from '../../Core/guards/canLoginGuard';
import { SignUp } from './signUp/signUp';
import { ValidateOTP } from './validateOtp/validateOtp';

export const routes: Routes = [
  { path: 'Register', component: SignUp, canActivate: [canLoginGuard] },
  { path: 'SetPas', component: SetPassword, canActivate: [canLoginGuard] },
  { path: 'OTPValidation', component: ValidateOTP },
];
