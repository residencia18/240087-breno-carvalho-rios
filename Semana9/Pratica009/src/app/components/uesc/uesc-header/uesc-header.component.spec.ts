import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescHeaderComponent } from './uesc-header.component';

describe('UescHeaderComponent', () => {
  let component: UescHeaderComponent;
  let fixture: ComponentFixture<UescHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescHeaderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
