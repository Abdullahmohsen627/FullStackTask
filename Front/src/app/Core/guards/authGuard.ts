import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  if (localStorage.getItem('token') != null) {
    const r = inject(Router);
    r.navigate(['/Home']);
    return false;
  }
  return true;
};
