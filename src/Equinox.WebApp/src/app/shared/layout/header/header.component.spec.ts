/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from "@angular/core/testing";
import { HeaderComponent } from "./header.component";

import { UserblockService } from "../sidebar/userblock/userblock.service";
import { SettingsService } from "../../../core/settings/settings.service";
import { MenuService } from "../../../core/menu/menu.service";

describe("Component: Header", () => {

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [MenuService, UserblockService, SettingsService]
        }).compileComponents();
    });

    it("should create an instance", async(inject([MenuService, UserblockService, SettingsService], (menuService, userblockService, settingsService) => {
        let component = new HeaderComponent(menuService, userblockService, settingsService);
        expect(component).toBeTruthy();
    })));
});
