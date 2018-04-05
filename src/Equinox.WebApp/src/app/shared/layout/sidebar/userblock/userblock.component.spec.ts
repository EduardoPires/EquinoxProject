/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from "@angular/core/testing";

import { UserblockComponent } from "./userblock.component";
import { UserblockService } from "./userblock.service";
import { SettingsService } from "../../../../core/settings/settings.service";
import { BrowserDynamicTestingModule, platformBrowserDynamicTesting } from "@angular/platform-browser-dynamic/testing";
import { AppComponent } from "../../../../app.component";
import { HttpClientModule } from "@angular/common/http";

describe("Component: Userblock", () => {

    beforeEach(() => {
        TestBed.resetTestEnvironment();
        TestBed.initTestEnvironment(BrowserDynamicTestingModule,
            platformBrowserDynamicTesting());

        TestBed.configureTestingModule({
            imports: [HttpClientModule],
            providers: [UserblockService, SettingsService]
        });
    });

    it("should create an instance", async(inject([UserblockService, SettingsService], (userBlockService, settingsService) => {
        let component = new UserblockComponent(userBlockService, settingsService);
        expect(component).toBeTruthy();
    })));
});
