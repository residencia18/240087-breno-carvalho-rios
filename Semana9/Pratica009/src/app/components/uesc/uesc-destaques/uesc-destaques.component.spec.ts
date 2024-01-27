import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescDestaquesComponent } from './uesc-destaques.component';

describe('UescDestaquesComponent', () => {
  let component: UescDestaquesComponent;
  let fixture: ComponentFixture<UescDestaquesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescDestaquesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescDestaquesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
