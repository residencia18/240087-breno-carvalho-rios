import { TestBed } from '@angular/core/testing';

import { WikipediaArticlesService } from './wikipedia-articles.service';

describe('WikipediaArticlesService', () => {
  let service: WikipediaArticlesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WikipediaArticlesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
