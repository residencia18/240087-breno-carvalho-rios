import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateTarefaComponent } from './update-tarefa.component';

describe('UpdateTarefaComponent', () => {
  let component: UpdateTarefaComponent;
  let fixture: ComponentFixture<UpdateTarefaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateTarefaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateTarefaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
