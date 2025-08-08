import { Injectable } from '@angular/core';
import { UserDTO } from '../DTOs/user-dto';

@Injectable({
  providedIn: 'root',
})
export class Details {
  details: UserDTO = new UserDTO('', '', '', '', '', '', '', '');
  getDetails(): UserDTO {
    return this.details;
  }
  setDetails(details: UserDTO): void {
    this.details = details;
  }
}
