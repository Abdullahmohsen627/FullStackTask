import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidateOTP } from './validate-otp';

describe('ValidateOTP', () => {
  let component: ValidateOTP;
  let fixture: ComponentFixture<ValidateOTP>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ValidateOTP]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ValidateOTP);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
