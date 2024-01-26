import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurismoMainComponent } from './turismo-main.component';

describe('TurismoMainComponent', () => {
  let component: TurismoMainComponent;
  let fixture: ComponentFixture<TurismoMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TurismoMainComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurismoMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
