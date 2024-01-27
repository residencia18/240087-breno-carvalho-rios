import { TestBed } from '@angular/core/testing';
import { UescDestaquesService } from './uesc-destaques.service';



describe('UescDestaquesService', () => {
  let service: UescDestaquesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UescDestaquesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
