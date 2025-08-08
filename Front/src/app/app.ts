import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SetPassword } from './Components/Registration/set-password/set-password';
import { ValidateOTP } from './Components/Registration/validate-otp/validate-otp';
import { SignUp } from './Components/Registration/sign-up/sign-up';
import { Login } from './Components/login/login';
import { Home } from './Components/home/home';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SetPassword, ValidateOTP, SignUp, Login,Home],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected title = 'Task';
}
