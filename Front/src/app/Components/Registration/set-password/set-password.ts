import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PasswordModule } from 'primeng/password';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { UserDTO } from '../../../DTOs/user-dto';
import { Details } from '../../../_Services/details';

@Component({
  selector: 'app-set-password',
  imports: [RouterLink, PasswordModule, FormsModule, CommonModule],
  templateUrl: './set-password.html',
  styleUrl: './set-password.css',
})
export class SetPassword {
  constructor(
    public router: Router,
    public http: HttpClient,
    public details: Details
  ) {}
  value1: string = '';
  value2: string = '';
  isValid: boolean = true;
  validatePassword() {
    // Logic to validate password
    if (this.isValid == true && this.value1.length >= 6) {
      console.log('Passwords match');
      this.isValid = true;
      if (this.details.getDetails()) {
        let useinf: UserDTO = this.details.getDetails();
        useinf.password = this.value1; // Set the password
        useinf.confirmPassword = this.value2; // Set the confirm password
        this.http
          .post('https://localhost:7146/api/Registration/setPassword', useinf, {
            responseType: 'text',
          })
          .subscribe((response) => {
            console.log('Password set successfully:', response);
            this.router.navigateByUrl('/LogIn');
          });
      }
    } else {
      console.log('Passwords do not match');
      this.isValid = false;
    }
  }
}
