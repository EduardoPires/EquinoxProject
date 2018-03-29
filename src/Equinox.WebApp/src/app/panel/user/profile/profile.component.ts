import { Component, OnInit } from "@angular/core";
import { ChangePasswordViewModel } from "../../../shared/viewModel/changePassword.model";
import { SettingsService } from "../../../core/settings/settings.service";


@Component({
    selector: "app-home",
    templateUrl: "./profile.component.html",
    styleUrls: ["./profile.component.scss"]
})
export class ProfileComponent implements OnInit {

    public ChangePass: ChangePasswordViewModel;
    constructor(public settings: SettingsService) { }

    ngOnInit() {
        this.ChangePass = new ChangePasswordViewModel();
    }

    public ChangePassword() {

    }
}
