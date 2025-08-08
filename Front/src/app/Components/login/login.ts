
import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Authentication } from '../../_Services/aurhentication';
import { LoginDTO } from '../../DTOs/login-dto';
import { PasswordModule } from 'primeng/password';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Details } from '../../_Services/details';

@Component({
  selector: 'app-login',
  imports: [RouterLink, PasswordModule, FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
})
export class Login {
  username: string = '';
  password: string = '';
  isValidPass: boolean = true;
  isValidEmail: boolean = true;

  constructor(public auth: Authentication, public router: Router,public details:Details) {}

 
  checkEmail() {
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    this.isValidEmail = emailPattern.test(this.username);
  }

  checkPass() {
    const passPattern = /^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.{6,})/;
    this.isValidPass = passPattern.test(this.password);
  }

  login() {
    this.checkEmail();
    this.checkPass();

    if (this.isValidEmail && this.isValidPass) {
      this.auth.logIn(new LoginDTO(this.username, this.password));
    } else {
      console.warn('Invalid email or password');
    }
  }
}
