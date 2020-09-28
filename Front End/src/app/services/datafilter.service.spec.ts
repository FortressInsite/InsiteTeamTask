import { TestBed } from '@angular/core/testing';

import { DatafilterService } from './datafilter.service';

describe('DatafilterService', () => {
  let service: DatafilterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatafilterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
