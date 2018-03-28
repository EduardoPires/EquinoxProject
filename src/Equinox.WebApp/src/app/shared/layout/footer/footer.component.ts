import { Component, OnInit } from "@angular/core";
import { SettingsService } from "../../../core/settings/settings.service";

@Component({
    // tslint:disable-next-line:component-selector
    selector: "[app-footer]",
    templateUrl: "./footer.component.html",
    styleUrls: ["./footer.component.scss"]
})
export class FooterComponent implements OnInit {

    constructor(public settings: SettingsService) { }

    ngOnInit() {

    }

}
