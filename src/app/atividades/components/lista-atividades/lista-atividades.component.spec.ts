import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaAtividadesComponent } from './lista-atividades.component';

describe('ListaAtividadesComponent', () => {
  let component: ListaAtividadesComponent;
  let fixture: ComponentFixture<ListaAtividadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListaAtividadesComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(ListaAtividadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
