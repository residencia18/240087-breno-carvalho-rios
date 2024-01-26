import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WikipediaMainComponent } from './wikipedia-main.component';

describe('WikipediaMainComponent', () => {
  let component: WikipediaMainComponent;
  let fixture: ComponentFixture<WikipediaMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WikipediaMainComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WikipediaMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
