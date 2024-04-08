import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { countriesResolver } from './countries.resolver';

describe('countriesResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => countriesResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
