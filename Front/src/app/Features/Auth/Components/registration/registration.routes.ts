import { Routes } from '@angular/router';
import { SetPassword } from './setPassword/setPassword';
import { SignUp } from './signUp/signUp';
import { ValidateOTP } from './validateOtp/validateOtp';

export const routes: Routes = [
  { path: 'Register', component: SignUp },
  { path: 'SetPas', component: SetPassword },
  { path: 'OTPValidation', component: ValidateOTP },
];
