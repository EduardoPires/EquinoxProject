import { Component, OnInit } from "@angular/core";
import { AccountManagementService } from "../services/account-management.service";
import { SettingsService } from "../../core/settings/settings.service";
import { Router } from "@angular/router";

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
