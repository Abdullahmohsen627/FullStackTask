import { TestBed } from '@angular/core/testing';

import { Details } from './details';

describe('Details', () => {
  let service: Details;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Details);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
