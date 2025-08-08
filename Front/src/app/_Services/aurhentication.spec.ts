import { TestBed } from '@angular/core/testing';

import { Aurhentication } from './aurhentication';

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
