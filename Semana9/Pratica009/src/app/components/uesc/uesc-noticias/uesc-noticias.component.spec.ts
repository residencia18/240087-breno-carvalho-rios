import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UescNoticiasComponent } from './uesc-noticias.component';

describe('UescNoticiasComponent', () => {
  let component: UescNoticiasComponent;
  let fixture: ComponentFixture<UescNoticiasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UescNoticiasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UescNoticiasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
