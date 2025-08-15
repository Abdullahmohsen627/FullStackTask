import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PasswordModule } from 'primeng/password';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { Details } from '../../../../../Core/services/details';
import { Registration } from '../../../Services/registration';
import { UserDTO } from '../../../../../DTOs/user-dto';

@Component({
  selector: 'app-set-password',
  imports: [RouterLink, PasswordModule, FormsModule, CommonModule],
  templateUrl: './setPassword.html',
  styleUrl: './setpassword.css',
})
export class SetPassword {
  constructor(
    public router: Router,
    public http: HttpClient,
    public details: Details,
    public registration: Registration
  ) {}
  value1: string = '';
  value2: string = '';
  isMatched: boolean = true;
  isStrong: boolean = true;
  strongPassword() {
    const strongPattern = /^(?=.*[A-Z])(?=.*[!@#$%^&*]).{6,}$/;
    this.isStrong = strongPattern.test(this.value1);
  }
  validatePassword() {
    if (this.isMatched == true && this.value1.length >= 6 && this.isStrong) {
      console.log('Passwords match');
      if (this.details.getDetails()) {
        let useInf: UserDTO = this.details.getDetails();
        useInf.password = this.value1; // Set the password
        useInf.confirmPassword = this.value2; // Set the confirm password
        this.registration.setPassword(useInf);
      }
    } else {
      console.log('Passwords do not match');
    }
  }
}
