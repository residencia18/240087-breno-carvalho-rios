import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescCardComponent } from './uesc-card.component';

describe('UescCardComponent', () => {
  let component: UescCardComponent;
  let fixture: ComponentFixture<UescCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
