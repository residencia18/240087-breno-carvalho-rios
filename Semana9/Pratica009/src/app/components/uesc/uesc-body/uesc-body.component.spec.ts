import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescBodyComponent } from './uesc-body.component';

describe('UescBodyComponent', () => {
  let component: UescBodyComponent;
  let fixture: ComponentFixture<UescBodyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescBodyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
