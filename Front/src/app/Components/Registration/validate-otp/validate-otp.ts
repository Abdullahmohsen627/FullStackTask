import { asNativeElements, Component } from '@angular/core';
import { EmailOTPDTO } from '../../../DTOs/email-otpdto';
import { InputOtpModule } from 'primeng/inputotp';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';
import { TooltipModule } from 'primeng/tooltip';
import { Router, RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Details } from '../../../_Services/details';
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
  templateUrl: './validate-otp.html',
  styleUrl: './validate-otp.css',
})
export class ValidateOTP {
  constructor(
    public router: Router,
    public http: HttpClient,
    public details: Details
  ) {}
  emailOTP: EmailOTPDTO = new EmailOTPDTO('', '');
  Valid: string = '';
  value: string = '';
  validateOTP() {
    // Logic to validate OTP
    this.emailOTP.Email = this.details.getDetails().email; // Assuming email is stored in UserDTO
    this.emailOTP.OTP = this.value;
    this.http
      .post(
        'https://localhost:7146/api/Registration/ValidateOTP',
        this.emailOTP,
        { responseType: 'text' }
      )
      .subscribe((response) => {
        this.Valid = response; // Assuming the response is a string indicating validity
        if (this.Valid) {
          console.log('OTP is valid');
          this.emailOTP.OTP = this.value;
          this.router.navigateByUrl('/SetPas');
        } else {
          console.log('OTP is invalid');
        }
      });
  }
  resendCode() {
    // Logic to resend OTP
    let email: string | null = this.details.getDetails().email; // Get email from UserDTO
    console.log('Resending OTP...');
    this.value = ''; // Clear the input field if OTP is invalid
    const eles = document.querySelectorAll(
      '.custom-otp-input'
    ) as NodeListOf<HTMLInputElement>;
    eles.forEach(
      (ele) => (ele.value = '') // Clear all input fields
    );
    // Here you would typically call a service to resend the OTP
    this.http
      .post(
        'https://localhost:7146/api/Registration/GetNewOTP/',
        JSON.stringify(email),
        {
          headers: { 'Content-Type': 'application/json' },
        }
      )
      .subscribe((s) => console.log(s)); // Clear the input field after resending
  }
}
