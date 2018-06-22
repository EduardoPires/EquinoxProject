import { Component, OnDestroy, OnInit } from "@angular/core";
import { SettingsService } from "../../core/settings/settings.service";
import { FormGroup, FormBuilder, Validators, FormControl, ValidationErrors } from "@angular/forms";
import { CustomValidators } from "ng2-validation";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { ActivatedRoute, Router } from "@angular/router";
import { isArray, isBoolean } from "util";
import { Subscription } from "rxjs/Subscription";
import { RegisterModel } from "../../shared/viewModel/register.model";
import { Observable } from "rxjs/Observable";
import { environment } from "../../../environments/environment";
import { Subject } from "rxjs/Subject";
import { DefaultResponse } from "../../shared/viewModel/defaultResponse.model";
import { ResetPasswordModel } from "../../shared/viewModel/reset-password.model";

@Component({
    selector: "app-reset-password",
    templateUrl: "./reset-password.component.html",
    styleUrls: ["./reset-password.component.scss"],
    providers: [AuthenticationService]
})
export class ResetPasswordComponent implements OnInit, OnDestroy {

    private valForm: FormGroup;
    private passwordForm: FormGroup;
    private googleForm: FormGroup;
    private resetPass: ResetPasswordModel;
    public errors: Array<string>;
    public telefoneMask: Array<string | RegExp>;

    public showButtonLoading: boolean;
    public passChanged: boolean;
    private resetPassSub: Subscription;


    constructor(public settings: SettingsService,
        fb: FormBuilder,
        private authService: AuthenticationService,
        private router: Router,
        private route: ActivatedRoute) {

        let password = new FormControl("", Validators.compose([Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/g)]));

        let certainPassword = new FormControl("", CustomValidators.equalTo(password));

        this.passwordForm = fb.group({
            "password": password,
            "confirmPassword": certainPassword
        });

        this.valForm = fb.group({
            "passwordGroup": this.passwordForm,
        });

    }


    public ngOnDestroy() {
        this.resetPassSub.unsubscribe();
    }

    public ngOnInit() {
        this.resetPass = new ResetPasswordModel();
        this.resetPassSub = this.route
            .queryParams
            .subscribe(params => {
                // Defaults to 0 if no query param provided.
                console.log(params);
                if (params == null || params.code == null || params.email == null) {
                    this.router.navigate(["/recover"]);
                    return;
                }
                this.resetPass.code = params.code;
                this.resetPass.email = params.email;
            });
        this.showButtonLoading = false;

        this.errors = [];
    }


    public async submitForm($ev, value: any) {
        $ev.preventDefault();
        for (let c in this.valForm.controls) {
            this.valForm.controls[c].markAsTouched();
        }
        for (let c in this.passwordForm.controls) {
            this.passwordForm.controls[c].markAsTouched();
        }

        if (this.valForm.valid) {
            this.showButtonLoading = true;
            this.resetPass.confirmPassword = this.valForm.get("passwordGroup.password").value;
            this.resetPass.password = this.valForm.get("passwordGroup.password").value;

            try {

                this.authService.resetPassword(this.resetPass).subscribe(
                    registerResult => {
                        if (registerResult.data.succeeded) this.passChanged = true;
                        else registerResult.data.errors.forEach(i => this.errors.push(i.description));

                        this.showButtonLoading = false;
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

            } catch (error) {
                this.errors = [];
                this.errors.push("Unknown error while trying to reset password");
                this.showButtonLoading = false;
            }
        }
    }

    private gup(url, name): string {
        name = name.replace(/[[]/, "\[").replace(/[]]/, "\]");
        let regexS = "[\?&]" + name + "=([^&#]*)";
        let regex = new RegExp(regexS);
        let results = regex.exec(url);
        if (results == null)
            return "";
        else
            return results[1];
    }
}
