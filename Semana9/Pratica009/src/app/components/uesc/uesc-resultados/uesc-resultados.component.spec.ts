import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescResultadosComponent } from './uesc-resultados.component';

describe('UescResultadosComponent', () => {
  let component: UescResultadosComponent;
  let fixture: ComponentFixture<UescResultadosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescResultadosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescResultadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
