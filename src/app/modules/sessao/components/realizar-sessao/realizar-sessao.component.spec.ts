import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RealizarSessaoComponent } from './realizar-sessao.component';

describe('RealizarSessaoComponent', () => {
  let component: RealizarSessaoComponent;
  let fixture: ComponentFixture<RealizarSessaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RealizarSessaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RealizarSessaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
