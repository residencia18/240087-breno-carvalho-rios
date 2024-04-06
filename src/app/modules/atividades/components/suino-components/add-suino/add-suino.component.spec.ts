import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSuinoComponent } from './add-suino.component';

describe('AddSuinoComponent', () => {
  let component: AddSuinoComponent;
  let fixture: ComponentFixture<AddSuinoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddSuinoComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(AddSuinoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
