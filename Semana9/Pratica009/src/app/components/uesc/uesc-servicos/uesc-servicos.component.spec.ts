import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescServicosComponent } from './uesc-servicos.component';

describe('UescServicosComponent', () => {
  let component: UescServicosComponent;
  let fixture: ComponentFixture<UescServicosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescServicosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescServicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
