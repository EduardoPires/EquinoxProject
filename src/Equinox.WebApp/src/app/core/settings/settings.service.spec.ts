/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from "@angular/core/testing";
import { SettingsService } from "./settings.service";
import { HttpClientModule } from "@angular/common/http";

describe("Service: Settings", () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      providers: [SettingsService]
    });
  });

  it("should ...", inject([SettingsService], (service: SettingsService) => {
    expect(service).toBeTruthy();
  }));
});
