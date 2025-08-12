import { TestBed } from '@angular/core/testing';

import { Aurhentication } from './authentication';

describe('Aurhentication', () => {
  let service: Aurhentication;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Aurhentication);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
