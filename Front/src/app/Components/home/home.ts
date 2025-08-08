import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Authentication } from '../../_Services/aurhentication';
import { HttpClient } from '@angular/common/http';
import { response } from 'express';
import { Details } from '../../_Services/details';

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
    public details: Details
  ) {}
  message: string = '';
  src: string = '';
  ngOnInit() {
    this.http
      .get('https://localhost:7146/api/Home', {
        responseType: 'text',
      })
      .subscribe((message) => {
        this.message = message; // Assuming the API returns an object with a 'username' property
      });
    this.src = `https://localhost:7146/uploads/images/${
      this.details.getDetails().logoUrl
    }`;
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
