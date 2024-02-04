import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleDisplayComponent } from './vehicle-display.component';

describe('VehicleDisplayComponent', () => {
  let component: VehicleDisplayComponent;
  let fixture: ComponentFixture<VehicleDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VehicleDisplayComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VehicleDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
