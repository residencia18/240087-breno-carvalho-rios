import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WikipediaArticlesListComponent } from './wikipedia-articles-list.component';

describe('WikipediaArticlesListComponent', () => {
  let component: WikipediaArticlesListComponent;
  let fixture: ComponentFixture<WikipediaArticlesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WikipediaArticlesListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WikipediaArticlesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
