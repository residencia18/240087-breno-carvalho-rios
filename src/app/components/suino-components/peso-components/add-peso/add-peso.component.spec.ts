import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPesoComponent } from './add-peso.component';

describe('AddPesoComponent', () => {
  let component: AddPesoComponent;
  let fixture: ComponentFixture<AddPesoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddPesoComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(AddPesoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
