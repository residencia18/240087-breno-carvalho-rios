import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardAtendimentoComponent } from './card-atendimento.component';

describe('CardAtendimentoComponent', () => {
  let component: CardAtendimentoComponent;
  let fixture: ComponentFixture<CardAtendimentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CardAtendimentoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardAtendimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
