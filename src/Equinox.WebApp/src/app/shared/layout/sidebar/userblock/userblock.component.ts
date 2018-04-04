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
    }

    userBlockIsVisible() {
        return this.userblockService.getVisibility();
    }

}
