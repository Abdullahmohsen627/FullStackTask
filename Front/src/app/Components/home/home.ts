import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Authentication } from '../../Core/services/authentication';
import { HttpClient } from '@angular/common/http';
import { Details } from '../../Core/services/details';
import { environment } from '../../../environments/environments';
import { home } from '../../Core/services/home';

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
      this.message = mess;
      this.src = this.photosUrl + `${this.details.getDetails().logoUrl}`;
    });

    console.log(this.details.getDetails());
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
