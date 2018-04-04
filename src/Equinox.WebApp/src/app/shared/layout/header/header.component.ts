import { Component, OnInit, ViewChild } from "@angular/core";
const screenfull = require("screenfull");
const browser = require("jquery.browser");
declare var $: any;

import { UserblockService } from "../sidebar/userblock/userblock.service";
import { SettingsService } from "../../../core/settings/settings.service";
import { MenuService } from "../../../core/menu/menu.service";
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
import { AuthenticationService } from "../../services/authentication.service";
import { Router } from "@angular/router";
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
<<<<<<< HEAD
=======
=======
import { AuthenticationService } from "../../services/authentication.service";
import { Router } from "@angular/router";
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
import { AuthenticationService } from "../../services/authentication.service";
import { Router } from "@angular/router";
>>>>>>> c3e8855... Fixing rebase errors


@Component({
    selector: "app-header",
    templateUrl: "./header.component.html",
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
    styleUrls: ["./header.component.scss"],
    providers: [AuthenticationService]
=======
    styleUrls: ["./header.component.scss"]
>>>>>>> fd1205c... Bug fix while creating new Db.
<<<<<<< HEAD
=======
=======
    styleUrls: ["./header.component.scss"],
    providers: [AuthenticationService]
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
    styleUrls: ["./header.component.scss"],
    providers: [AuthenticationService]
>>>>>>> c3e8855... Fixing rebase errors
})
export class HeaderComponent implements OnInit {

    navCollapsed = true; // for horizontal layout
    menuItems = []; // for horizontal layout

    isNavSearchVisible: boolean;
    @ViewChild("fsbutton") fsbutton;  // the fullscreen button

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
    constructor(
        public menu: MenuService,
        public userblockService: UserblockService,
        public settings: SettingsService,
        public authService: AuthenticationService,
        private router: Router) {
<<<<<<< HEAD
<<<<<<< HEAD
=======
    constructor(public menu: MenuService, public userblockService: UserblockService, public settings: SettingsService) {
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
<<<<<<< HEAD
=======
    constructor(public menu: MenuService, public userblockService: UserblockService, public settings: SettingsService) {
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors

        // show only a few items on demo
        this.menuItems = menu.getMenu().slice(0, 4); // for horizontal layout

    }

    ngOnInit() {
        this.isNavSearchVisible = false;
        if (browser.msie) { // Not supported under IE
            this.fsbutton.nativeElement.style.display = "none";
        }
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
    public async logout() {
        let result = await this.authService.logout().toPromise();
        if (result.data) {
            this.router.navigate(["/"]);
        }
    }

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
    toggleUserBlock(event) {
        event.preventDefault();
        this.userblockService.toggleVisibility();
    }

    openNavSearch(event) {
        event.preventDefault();
        event.stopPropagation();
        this.setNavSearchVisible(true);
    }

    setNavSearchVisible(stat: boolean) {
        // console.log(stat);
        this.isNavSearchVisible = stat;
    }

    getNavSearchVisible() {
        return this.isNavSearchVisible;
    }

    toggleOffsidebar() {
        this.settings.layout.offsidebarOpen = !this.settings.layout.offsidebarOpen;
    }

    toggleCollapsedSideabar() {
        this.settings.layout.isCollapsed = !this.settings.layout.isCollapsed;
    }

    isCollapsedText() {
        return this.settings.layout.isCollapsedText;
    }

    toggleFullScreen(event) {

        if (screenfull.enabled) {
            screenfull.toggle();
        }
        // Switch icon indicator
        let el = $(this.fsbutton.nativeElement);
        if (screenfull.isFullscreen) {
            el.children("em").removeClass("fa-expand").addClass("fa-compress");
        }
        else {
            el.children("em").removeClass("fa-compress").addClass("fa-expand");
        }
    }
}
