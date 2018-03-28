/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MenuService } from './menu.service';

describe('Service: Menu', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MenuService]
    });
  });

  it('should ...', inject([MenuService], (service: MenuService) => {
    expect(service).toBeTruthy();
  }));
});
