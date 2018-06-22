/* tslint:disable:no-unused-variable */
import { TestBed, async, inject } from "@angular/core/testing";
import { HeaderComponent } from "./header.component";

import { UserblockService } from "../sidebar/userblock/userblock.service";
import { SettingsService } from "../../../core/settings/settings.service";
import { MenuService } from "../../../core/menu/menu.service";
import { AuthenticationService } from "../../services/authentication.service";
import { Router } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";

describe("Component: Header", () => {
    let mockRouter = {
        navigate: jasmine.createSpy("navigate")
    };

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientModule],
            providers: [
                MenuService,
                UserblockService,
                SettingsService,
                AuthenticationService,
                { provide: Router, useValue: mockRouter }]
        }).compileComponents();
    });

    it("should create an instance", async(inject([
        MenuService,
        UserblockService,
        SettingsService,
        AuthenticationService,
        Router],
        (menuService, userblockService, settingsService, authService, router) => {

            let component = new HeaderComponent(menuService, userblockService, settingsService, authService, router);
            expect(component).toBeTruthy();
        })));
});
