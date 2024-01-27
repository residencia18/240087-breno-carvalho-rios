import { TestBed } from '@angular/core/testing';

import { UescResultadosService } from './uesc-resultados.service';

describe('UescResultadosService', () => {
  let service: UescResultadosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UescResultadosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
