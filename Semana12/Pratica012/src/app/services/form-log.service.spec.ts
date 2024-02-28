import { TestBed } from '@angular/core/testing';

import { FormLogService } from './form-log.service';

describe('FormLogService', () => {
  let service: FormLogService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormLogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
