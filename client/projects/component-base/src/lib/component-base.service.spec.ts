import { TestBed } from '@angular/core/testing';

import { ComponentBaseService } from './component-base.service';

describe('ComponentBaseService', () => {
  let service: ComponentBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ComponentBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
