import { TestBed } from '@angular/core/testing';

import { UescServicosService } from './uesc-servicos.service';

describe('UescServicosService', () => {
  let service: UescServicosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UescServicosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
