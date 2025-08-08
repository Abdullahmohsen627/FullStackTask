export class RegistrationDTO {
  constructor(
    public companyArabicName: string,
    public companyEnglishName: string,
    public email: string,
    public websiteUrl: string,
    public phoneNumber?: string,
    public logoUrl?: string | null
  ) {}
}
