import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardPesoComponent } from './card-peso.component';

describe('CardPesoComponent', () => {
  let component: CardPesoComponent;
  let fixture: ComponentFixture<CardPesoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CardPesoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardPesoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
