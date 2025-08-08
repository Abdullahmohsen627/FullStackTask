export class UserDTO {
  constructor(
    public companyArabicName: string,
    public companyEnglishName: string,
    public email: string,
    public phoneNumber: string,
    public websiteUrl: string,
    public logoUrl: string,
    public password: string,
    public confirmPassword: string
  ) {}
}
