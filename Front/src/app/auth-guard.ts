import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  if (localStorage.getItem('token')) {
    const r = inject(Router);
    r.navigate(['/Home']);
    return false;
  }
  return true;
};
