import { TestBed } from '@angular/core/testing';

import { EquipoMedicoService } from './equipo-medico.service';

describe('EquipoMedicoService', () => {
  let service: EquipoMedicoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EquipoMedicoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
