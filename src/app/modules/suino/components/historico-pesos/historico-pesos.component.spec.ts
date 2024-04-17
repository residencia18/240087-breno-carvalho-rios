import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricoPesosComponent } from './historico-pesos.component';

describe('HistoricoPesosComponent', () => {
  let component: HistoricoPesosComponent;
  let fixture: ComponentFixture<HistoricoPesosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HistoricoPesosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HistoricoPesosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
