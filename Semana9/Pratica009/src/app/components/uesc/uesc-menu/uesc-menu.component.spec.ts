import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescMenuComponent } from './uesc-menu.component';

describe('UescMenuComponent', () => {
  let component: UescMenuComponent;
  let fixture: ComponentFixture<UescMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescMenuComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
