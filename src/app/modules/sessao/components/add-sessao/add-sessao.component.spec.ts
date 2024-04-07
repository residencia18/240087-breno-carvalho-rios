import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSessaoComponent } from './add-sessao.component';

describe('AddSessaoComponent', () => {
  let component: AddSessaoComponent;
  let fixture: ComponentFixture<AddSessaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddSessaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddSessaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
