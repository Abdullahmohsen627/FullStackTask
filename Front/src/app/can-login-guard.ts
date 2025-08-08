import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

export const canLoginGuard: CanActivateFn = (route, state) => {
  let r = inject(HttpClient);
  if (localStorage.getItem('token')) {
    // If token exists, allow access to the route
    return r.get<boolean>('https://localhost:7146/api/Authentication');
  } else {
    let r = inject(Router);
    // Redirect to login if no token
    r.navigateByUrl('/LogIn');
    console.log('No token found, redirecting to login');
    return false; // If no token, block access
  }
};
