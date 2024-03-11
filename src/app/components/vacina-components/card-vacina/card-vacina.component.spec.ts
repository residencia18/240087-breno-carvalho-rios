import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardVacinaComponent } from './card-vacina.component';

describe('CardVacinaComponent', () => {
  let component: CardVacinaComponent;
  let fixture: ComponentFixture<CardVacinaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CardVacinaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardVacinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
