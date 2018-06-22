/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from "@angular/core/testing";
import { FooterComponent } from "./footer.component";

import { SettingsService } from "../../../core/settings/settings.service";
import { HttpClientModule } from "@angular/common/http";

describe("Component: Footer", () => {

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientModule],
            providers: [SettingsService]
        }).compileComponents();
    });

    it("should create an instance", async(inject([SettingsService], (settingsService) => {
        let component = new FooterComponent(settingsService);
        expect(component).toBeTruthy();
    })));
});
