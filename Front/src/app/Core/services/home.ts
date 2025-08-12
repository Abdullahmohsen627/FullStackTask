import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environments';
import { Details } from './details';

@Injectable({
  providedIn: 'root',
})
export class home {
  constructor(public http: HttpClient, public details: Details) {}
  baseUrl = environment.BaseUrl;
  photosUrl = environment.photosUrl;
  homecontent() {
    return this.http.get(this.baseUrl + 'Home', {
      responseType: 'text',
    });
  }
}
