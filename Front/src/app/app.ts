import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SetPassword } from './Components/registration/setPassword/setPassword';
import { ValidateOTP } from './Components/registration/validateOtp/validateOtp';
import { SignUp } from './Components/registration/signUp/signUp';
import { Login } from './Components/login/login';
import { Home } from './Components/home/home';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SetPassword, ValidateOTP, SignUp, Login, Home],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected title = 'Task';
}
