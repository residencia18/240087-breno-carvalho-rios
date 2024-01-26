import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescMainComponent } from './uesc-main.component';

describe('UescMainComponent', () => {
  let component: UescMainComponent;
  let fixture: ComponentFixture<UescMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescMainComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
