/* tslint:disable:no-unused-variable */
import { TestBed, async, inject } from "@angular/core/testing";
import { SidebarComponent } from "./sidebar.component";
import { RouterModule, Router } from "@angular/router";

import { MenuService } from "../../../core/menu/menu.service";
import { SettingsService } from "../../../core/settings/settings.service";

describe("Component: Sidebar", () => {
    let mockRouter = {
        navigate: jasmine.createSpy("navigate")
    };
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                MenuService,
                SettingsService,
                { provide: Router, useValue: mockRouter }
            ]
        }).compileComponents();
    });

    it("should create an instance", async(inject([MenuService, SettingsService, Router], (menuService, settingsService, router) => {
        let component = new SidebarComponent(menuService, settingsService, router);
        expect(component).toBeTruthy();
    })));
});
