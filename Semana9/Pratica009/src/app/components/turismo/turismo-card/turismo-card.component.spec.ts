import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurismoCardComponent } from './turismo-card.component';

describe('TurismoCardComponent', () => {
  let component: TurismoCardComponent;
  let fixture: ComponentFixture<TurismoCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TurismoCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurismoCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
