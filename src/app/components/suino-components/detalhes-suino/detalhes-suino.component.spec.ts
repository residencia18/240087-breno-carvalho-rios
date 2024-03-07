import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesSuinoComponent } from './detalhes-suino.component';

describe('DetalhesSuinoComponent', () => {
  let component: DetalhesSuinoComponent;
  let fixture: ComponentFixture<DetalhesSuinoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetalhesSuinoComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(DetalhesSuinoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
