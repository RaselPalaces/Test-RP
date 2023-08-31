import { TestBed } from '@angular/core/testing';

import { OrdenReparacionService } from './orden-reparacion.service';

describe('OrdenReparacionService', () => {
  let service: OrdenReparacionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrdenReparacionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
