import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../../environments/environments';
import { Details } from '../../../Core/services/details';
import { UserDTO } from '../../../DTOs/user-dto';
import { LoginDTO } from '../DTOs/login-dto';

@Injectable({
  providedIn: 'root',
})
export class Authentication {
  constructor(
    public http: HttpClient,
    public router: Router,
    public details: Details
  ) {}
  private baseUrl = environment.BaseUrl;
  isloggedIn: boolean = false;
  logIn(logDTO: LoginDTO) {
    this.http
      .post(this.baseUrl + 'Authentication', logDTO, {
        responseType: 'text',
      })
      .subscribe((token) => {
        localStorage.setItem('token', token);
        console.log(token);
        this.isloggedIn = true;
        // Navigate to home after successful login
        this.http
          .get(this.baseUrl + `User?email=${encodeURIComponent(logDTO.Email)}`)
          .subscribe((info) => {
            this.details.setDetails(info as UserDTO);
            localStorage.setItem('logoUrl', this.details.getDetails().logoUrl); // Store user details
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
