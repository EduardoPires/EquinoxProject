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
                },
                response => {
                    this.errors = [];
                    response.error.errors.forEach(element => this.errors.push(element));
                }
            );
        }
    }

    public ngOnInit() {
        this.emailSent = false;
        this.errors = [];
    }

}
