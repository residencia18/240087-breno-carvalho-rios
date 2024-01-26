import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WikipediaSearchComponent } from './wikipedia-search.component';

describe('WikipediaSearchComponent', () => {
  let component: WikipediaSearchComponent;
  let fixture: ComponentFixture<WikipediaSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WikipediaSearchComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WikipediaSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
