import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../../../environments/environments';
import { Details } from '../../../../Core/services/details';
import { UserDTO } from '../../../../DTOs/user-dto';
import { Authentication } from '../../../Auth/Services/authentication';
import { home } from '../../Services/home';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements OnInit {
  constructor(
    public router: Router,
    public auth: Authentication,
    public http: HttpClient,
    public details: Details,
    public home: home
  ) {}
  private photosUrl = environment.photosUrl;
  message: string = '';
  src: string = '';
  ngOnInit() {
    this.home.homecontent().subscribe((mess) => {
      this.details.setDetails(mess as UserDTO);
      this.src = this.photosUrl + this.details.getDetails().logoUrl;
      this.message = 'Welcome ' + this.details.getDetails().companyEnglishName;
    });
  }
  // Add any methods or properties needed for the Home component
  logOut() {
    let con = confirm('Are you sure you want to log out?');
    if (con) {
      this.auth.logOut();
      this.router.navigateByUrl('/LogIn');
      console.log('Logged out successfully');
    } else {
      console.log('Logout cancelled');
    }
  }
}
