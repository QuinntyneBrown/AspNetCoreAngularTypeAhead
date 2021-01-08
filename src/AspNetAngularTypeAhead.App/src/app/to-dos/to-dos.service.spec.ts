import { TestBed } from '@angular/core/testing';

import { ToDosService } from './to-dos.service';

describe('ToDosService', () => {
  let service: ToDosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ToDosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
