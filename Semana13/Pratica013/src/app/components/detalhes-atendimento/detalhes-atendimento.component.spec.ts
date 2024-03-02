import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesAtendimentoComponent } from './detalhes-atendimento.component';

describe('DetalhesAtendimentoComponent', () => {
  let component: DetalhesAtendimentoComponent;
  let fixture: ComponentFixture<DetalhesAtendimentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetalhesAtendimentoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DetalhesAtendimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
