import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { CustomValidators } from "ng2-validation";
import { SettingsService } from "../../core/settings/settings.service";
import { AuthenticationService } from "../../shared/services/authentication.service";

@Component({
    selector: "app-recover",
    templateUrl: "./recover.component.html",
    styleUrls: ["./recover.component.scss"],
    providers: [AuthenticationService]
})
export class RecoverComponent implements OnInit {

    valForm: FormGroup;
    public errors: Array<string>;
    public emailSent: boolean;
    public showButtonLoading: boolean;

    constructor(
        public settings: SettingsService,
        fb: FormBuilder,
        private authService: AuthenticationService) {
        this.valForm = fb.group({
            "email": [null, Validators.compose([Validators.required, CustomValidators.email])]
        });
    }

    submitForm($ev, value: any) {
        this.errors = [];
        $ev.preventDefault();
        this.showButtonLoading = true;
        for (let c in this.valForm.controls) {
            this.valForm.controls[c].markAsTouched();
        }
        if (this.valForm.valid) {
            this.authService.recoverPassword(this.valForm.controls["email"].value).subscribe(
                recoverResult => {
                    if (recoverResult.data) {
                        this.emailSent = true;
                    } else {
                        this.errors.push("E-mail not found");
                    }
                    this.showButtonLoading = true;
                },
                response => {
                    this.errors = [];
                    if (response.error.errors != null)
                        response.error.errors.forEach(element => this.errors.push(element));
                    else {
                        this.errors.push("Unknown error while trying to reset password");
                    }
                    this.showButtonLoading = false;
                }
            );
        }
    }

    public ngOnInit() {
        this.emailSent = false;
        this.errors = [];
    }

}
