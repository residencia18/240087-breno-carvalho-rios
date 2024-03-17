import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaVacinasComponent } from './lista-vacinas.component';

describe('ListaVacinasComponent', () => {
  let component: ListaVacinasComponent;
  let fixture: ComponentFixture<ListaVacinasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListaVacinasComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(ListaVacinasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
