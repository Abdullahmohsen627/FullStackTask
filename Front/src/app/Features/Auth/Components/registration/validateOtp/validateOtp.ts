import { Component } from '@angular/core';

import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { InputOtpModule } from 'primeng/inputotp';
import { TooltipModule } from 'primeng/tooltip';
import { environment } from '../../../../../../environments/environments';
import { Details } from '../../../../../Core/services/details';
import { EmailOTPDTO } from '../../../DTOs/emailOtp-dto';
import { Registration } from '../../../Services/registration';

@Component({
  selector: 'app-validate-otp',
  imports: [
    InputOtpModule,
    FormsModule,
    ButtonModule,
    CommonModule,
    TooltipModule,
    RouterLink,
  ],
  templateUrl: './validateOtp.html',
  styleUrl: './validateOtp.css',
})
export class ValidateOTP {
  constructor(
    public router: Router,
    public http: HttpClient,
    public details: Details,
    public registration: Registration
  ) {}
  baseUrl = environment.BaseUrl;
  emailOTP: EmailOTPDTO = new EmailOTPDTO('', '');
  Valid: string = '';
  value: string = '';
  validateOTP() {
    // Logic to validate OTP
    this.emailOTP.Email = this.details.getDetails().email; // Assuming email is stored in UserDTO
    this.emailOTP.OTP = this.value;
    this.registration.sendOTP(this.emailOTP);
  }
  resendCode() {
    // Logic to resend OTP
    let email: string = this.details.getDetails().email; // Get email from UserDTO
    console.log('Resending OTP...');
    this.value = ''; // Clear the input field if OTP is invalid
    const eles = document.querySelectorAll(
      '.custom-otp-input'
    ) as NodeListOf<HTMLInputElement>;
    eles.forEach(
      (ele) => (ele.value = '') // Clear all input fields
    );
    // Here you would typically call a service to resend the OTP
    this.registration.resendOTP(email);
  }
}
