import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricoSuinoComponent } from './historico-suino.component';

describe('HistoricoSuinoComponent', () => {
  let component: HistoricoSuinoComponent;
  let fixture: ComponentFixture<HistoricoSuinoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HistoricoSuinoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HistoricoSuinoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
