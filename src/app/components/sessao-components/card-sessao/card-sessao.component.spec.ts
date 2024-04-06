import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardSessaoComponent } from './card-sessao.component';

describe('CardSessaoComponent', () => {
  let component: CardSessaoComponent;
  let fixture: ComponentFixture<CardSessaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CardSessaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardSessaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
