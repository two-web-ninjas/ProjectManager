import { TestBed } from '@angular/core/testing';

import { ComponentUiService } from './component-ui.service';

describe('ComponentUiService', () => {
  let service: ComponentUiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ComponentUiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
