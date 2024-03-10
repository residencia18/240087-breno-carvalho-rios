import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardSuinoComponent } from './card-suino.component';

describe('CardSuinoComponent', () => {
  let component: CardSuinoComponent;
  let fixture: ComponentFixture<CardSuinoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CardSuinoComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CardSuinoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
