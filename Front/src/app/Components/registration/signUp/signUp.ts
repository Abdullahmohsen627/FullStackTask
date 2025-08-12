import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { RegistrationDTO } from '../../../DTOs/registration-dto';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { UserDTO } from '../../../DTOs/user-dto';
import { Details } from '../../../Core/services/details';
import { Registration } from '../../../Core/services/registration';
import { environment } from '../../../../environments/environments';

@Component({
  selector: 'app-sign-up',
  imports: [RouterLink, CommonModule, FormsModule],
  templateUrl: './signUp.html',
  styleUrl: './signup.css',
})
export class SignUp {
  private baseUrl = environment.BaseUrl;
  model = new RegistrationDTO('', '', '', '', '', '');

  selectedFile: File | null = null;

  constructor(
    private http: HttpClient,
    public router: Router,
    public details: Details,
    public registration: Registration
  ) {}

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0] ?? null;
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
      const uploadedFileName = await this.registration.uploadLogo(
        this.selectedFile
      );
      this.model.logoUrl = uploadedFileName;
    }
    this.registration.signUp(this.model);
    // Navigate to the login page after submission
  }

  capitalize(value: string): string {
    if (!value) return '';
    return value.charAt(0).toUpperCase() + value.slice(1).toLowerCase();
  }
}
