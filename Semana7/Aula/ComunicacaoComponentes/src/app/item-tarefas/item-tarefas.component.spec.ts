import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemTarefasComponent } from './item-tarefas.component';

describe('ItemTarefasComponent', () => {
  let component: ItemTarefasComponent;
  let fixture: ComponentFixture<ItemTarefasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItemTarefasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItemTarefasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
