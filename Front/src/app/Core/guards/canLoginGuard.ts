import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environments';

export const canLoginGuard: CanActivateFn = (route, state) => {
  let r = inject(HttpClient);
  let baseUrl = environment.BaseUrl;
  if (localStorage.getItem('token')) {
    // If token exists, allow access to the route
    return r.get<boolean>(baseUrl + 'Authentication');
  } else {
    let w = inject(Router);
    // Redirect to login if no token
    w.navigateByUrl('/LogIn');
    console.log('No token found, redirecting to login');
    return false; // If no token, block access
  }
};
