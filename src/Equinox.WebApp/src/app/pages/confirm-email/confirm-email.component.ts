import { Component, OnInit, OnDestroy } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { CustomValidators } from "ng2-validation";
import { SettingsService } from "../../core/settings/settings.service";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { Subscription } from "rxjs/Subscription";
import { ConfirmEmailViewModel } from "../../shared/viewModel/confirm-email.model";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    selector: "app-confirm-email",
    templateUrl: "./confirm-email.component.html",
    styleUrls: ["./confirm-email.component.scss"],
    providers: [AuthenticationService]
})
export class ConfirmEmailComponent implements OnInit, OnDestroy {

    public resetPassSub: Subscription;
    public errors: Array<string>;
    public confirmEmail: ConfirmEmailViewModel;
    public showButtonLoading: boolean;
    public emailConfirmed: boolean;

    constructor(
        public settings: SettingsService,
        private route: ActivatedRoute,
        private router: Router,
        private authService: AuthenticationService) {

    }

    public ngOnDestroy() {
        this.resetPassSub.unsubscribe();
    }

    public ngOnInit() {
        this.emailConfirmed = false;
        this.showButtonLoading = true;
        this.errors = [];
        this.confirmEmail = new ConfirmEmailViewModel();
        this.resetPassSub = this.route
            .queryParams
            .subscribe(params => {
                // Defaults to 0 if no query param provided.
                console.log(params);
                if (params == null || params.code == null || params.email == null) {
                    this.router.navigate(["/sign-in"]);
                    return;
                }
                this.confirmEmail.code = params.code;
                this.confirmEmail.email = params.email;
                this.authService.confirmEmail(this.confirmEmail).subscribe(
                    registerResult => {
                        if (registerResult.data.succeeded) this.emailConfirmed = true;
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
            });

    }
}
