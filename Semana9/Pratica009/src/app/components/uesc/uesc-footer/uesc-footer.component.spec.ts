import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescFooterComponent } from './uesc-footer.component';

describe('UescFooterComponent', () => {
  let component: UescFooterComponent;
  let fixture: ComponentFixture<UescFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescFooterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
