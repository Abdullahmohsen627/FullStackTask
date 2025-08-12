import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { UserDTO } from '../../DTOs/user-dto';
import { RegistrationDTO } from '../../DTOs/registration-dto';
import { Details } from './details';
import { environment } from '../../../environments/environments';
import { EmailOTPDTO } from '../../DTOs/email-otpdto';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Registration {
  constructor(
    public http: HttpClient,
    public router: Router,
    public details: Details
  ) {}
  private baseUrl = environment.BaseUrl;
  signUp(model: RegistrationDTO) {
    this.http
      .post<RegistrationDTO>(this.baseUrl + 'Registration', model)
      .subscribe((r) => {
        model = r;
        if (model) {
          this.router.navigateByUrl('/OTPValidation');
          // localStorage.setItem('data', JSON.stringify(data));
          this.details.setDetails(model as UserDTO);
          console.log('Details saved:', this.details.getDetails());
          console.log('Registration successful:', model);
        } else {
          console.log('Registration failed');
        }
      });
  }
  setPassword(useInf: UserDTO) {
    this.http
      .post(this.baseUrl + 'Registration/setPassword', useInf, {
        responseType: 'text',
      })
      .subscribe((response) => {
        console.log('Password set successfully:', response);
        this.router.navigateByUrl('/LogIn');
      });
  }
  resendOTP(email: string) {
    this.http
      .post(this.baseUrl + 'Registration/GetNewOTP/', JSON.stringify(email), {
        headers: { 'Content-Type': 'application/json' },
      })
      .subscribe((s) => console.log(s));
  }
  sendOTP(emailOTP: EmailOTPDTO) {
    this.http
      .post(this.baseUrl + 'Registration/ValidateOTP', emailOTP, {
        responseType: 'text',
      })
      .subscribe((response) => {
        if (response) {
          console.log('OTP is valid');
          this.router.navigateByUrl('/SetPas');
        } else {
          console.log('OTP is invalid');
        }
      });
  }
  async uploadLogo(selectedFile:File): Promise<string> {
    if (!selectedFile) return '';

    const formData = new FormData();
    formData.append('file', selectedFile);

    const uploadEndpoint = this.baseUrl + 'Registration/UploadLogo';
    return await firstValueFrom(
      this.http.post(uploadEndpoint, formData, { responseType: 'text' })
    );
  }
}
