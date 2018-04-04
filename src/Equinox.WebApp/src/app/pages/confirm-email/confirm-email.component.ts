import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { CustomValidators } from "ng2-validation";
import { SettingsService } from "../../core/settings/settings.service";
import { AuthenticationService } from "../../shared/services/authentication.service";

@Component({
    selector: "app-confirm-email",
    templateUrl: "./confirm-email.component.html",
    styleUrls: ["./confirm-email.component.scss"],
    providers: [AuthenticationService]
})
export class ConfirmEmailComponent implements OnInit {

    constructor(
        private authService: AuthenticationService) {

    }


    public ngOnInit() {
    }

}
