import { Component, OnInit } from "@angular/core";
<<<<<<< HEAD
<<<<<<< HEAD
import { AccountManagementService } from "../services/account-management.service";
import { SettingsService } from "../../core/settings/settings.service";
import { Router } from "@angular/router";
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { AccountManagementService } from "../services/account-management.service";
import { SettingsService } from "../../core/settings/settings.service";
import { Router } from "@angular/router";
>>>>>>> 86e6256... Daily commit

@Component({
    selector: "app-layout",
    templateUrl: "./layout.component.html",
    styleUrls: ["./layout.component.scss"]
})
export class LayoutComponent implements OnInit {

    constructor() { }

    ngOnInit() {
        (<any>window).preLoaderStart();
    }

}
