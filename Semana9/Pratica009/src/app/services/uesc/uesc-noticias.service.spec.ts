import { TestBed } from '@angular/core/testing';

import { UescNoticiasService } from './uesc-noticias.service';

describe('UescNoticiasService', () => {
  let service: UescNoticiasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UescNoticiasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
