import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompleteToDoComponent } from './complete-to-do.component';

describe('CompleteToDoComponent', () => {
  let component: CompleteToDoComponent;
  let fixture: ComponentFixture<CompleteToDoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompleteToDoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompleteToDoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
