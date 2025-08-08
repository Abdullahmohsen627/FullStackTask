import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { RegistrationDTO } from '../../../DTOs/registration-dto';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { UserDTO } from '../../../DTOs/user-dto';
import { Details } from '../../../_Services/details';

@Component({
  selector: 'app-sign-up',
  imports: [RouterLink, CommonModule, FormsModule],
  templateUrl: './sign-up.html',
  styleUrl: './sign-up.css',
})
export class SignUp {
  model = new RegistrationDTO('', '', '', '', '', '');

  selectedFile: File | null = null;

  constructor(
    private http: HttpClient,
    public router: Router,
    public details: Details
  ) {}

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0] ?? null;
  }

  async uploadLogo2(): Promise<string> {
    if (!this.selectedFile) return '';

    const formData = new FormData();
    formData.append('file', this.selectedFile);

    const uploadEndpoint = 'https://localhost:7146/api/Registration/UploadLogo';
    return await firstValueFrom(
      this.http.post(uploadEndpoint, formData, { responseType: 'text' })
    );
  }

  async onSubmit(): Promise<void> {
    // Capitalize first letter only
    this.model.companyArabicName = this.capitalize(
      this.model.companyArabicName
    );
    this.model.companyEnglishName = this.capitalize(
      this.model.companyEnglishName
    );
    // Upload logo if exists
    if (this.selectedFile) {
      const uploadedFileName = await this.uploadLogo2();
      this.model.logoUrl = uploadedFileName;
    }
    let data: RegistrationDTO | null = null;
    this.http
      .post<RegistrationDTO>(
        'https://localhost:7146/api/Registration',
        this.model
      )
      .subscribe((r) => {
        data = r;
        if (data) {
          this.router.navigateByUrl('/OTPValidation');
          // localStorage.setItem('data', JSON.stringify(data));
          this.details.setDetails(data as UserDTO);
          console.log('Details saved:', this.details.getDetails());
          console.log('Registration successful:', data);
        } else {
          console.log('Registration failed');
        }
      });
    // Navigate to the login page after submission
  }

  capitalize(value: string): string {
    if (!value) return '';
    return value.charAt(0).toUpperCase() + value.slice(1).toLowerCase();
  }
}
