import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAtendimentoComponent } from './add-atendimento.component';

describe('AddAtendimentoComponent', () => {
  let component: AddAtendimentoComponent;
  let fixture: ComponentFixture<AddAtendimentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddAtendimentoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddAtendimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
