import { Injectable } from '@angular/core';
import { LoginDTO } from '../DTOs/login-dto';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Details } from './details';
import { RegistrationDTO } from '../DTOs/registration-dto';
import { UserDTO } from '../DTOs/user-dto';
@Injectable({
  providedIn: 'root',
})
export class Authentication {
  constructor(
    public http: HttpClient,
    public router: Router,
    public details: Details
  ) {}
  isloggedIn: boolean = false;
  logIn(logDTO: LoginDTO) {
    this.http
      .post('https://localhost:7146/api/Authentication', logDTO, {
        responseType: 'text',
      })
      .subscribe((token) => {
        localStorage.setItem('token', token);
        console.log(token);
        this.isloggedIn = true;
        // Navigate to home after successful login
        this.http
          .get(
            `https://localhost:7146/api/User?email=${encodeURIComponent(
              logDTO.Email
            )}`
          )
          .subscribe((info) => {
            this.details.setDetails(info as UserDTO); // Store user details
            this.router.navigateByUrl('/Home');
          }); // Store user details
      });
  }
  logOut() {
    // Logic to log out the user
    localStorage.removeItem('token'); // Example of clearing token
    this.isloggedIn = false; // Update login status

    console.log('User logged out');
  }
}
