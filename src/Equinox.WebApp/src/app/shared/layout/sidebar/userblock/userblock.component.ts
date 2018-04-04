import { Component, OnInit } from "@angular/core";

import { UserblockService } from "./userblock.service";
import { SettingsService } from "../../../../core/settings/settings.service";
import { UserProfile } from "../../../viewModel/userProfile.model";
import { Observable } from "rxjs/Observable";

@Component({
    selector: "app-userblock",
    templateUrl: "./userblock.component.html",
    styleUrls: ["./userblock.component.scss"]
})
export class UserblockComponent implements OnInit {

    public user: UserProfile;

    constructor(public userblockService: UserblockService,
        public settings: SettingsService) {
    }

    ngOnInit() {
        this.settings.getProfile().subscribe(a => this.user = a);
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
=======
import { Component, OnInit } from '@angular/core';
=======
import { Component, OnInit } from "@angular/core";
>>>>>>> 86e6256... Daily commit

import { UserblockService } from "./userblock.service";
import { SettingsService } from "../../../../core/settings/settings.service";
import { UserProfile } from "../../../viewModel/userProfile.model";

@Component({
    selector: "app-userblock",
    templateUrl: "./userblock.component.html",
    styleUrls: ["./userblock.component.scss"]
})
export class UserblockComponent implements OnInit {

    public user: UserProfile;

    constructor(public userblockService: UserblockService,
        public settings: SettingsService) {
    }

    ngOnInit() {
>>>>>>> fd1205c... Bug fix while creating new Db.
<<<<<<< HEAD
=======
=======
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
    }

    userBlockIsVisible() {
        return this.userblockService.getVisibility();
    }

}
