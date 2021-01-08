import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateToDoComponent } from './create-to-do.component';

describe('CreateToDoComponent', () => {
  let component: CreateToDoComponent;
  let fixture: ComponentFixture<CreateToDoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateToDoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateToDoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
