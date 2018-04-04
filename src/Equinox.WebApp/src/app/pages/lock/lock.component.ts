import { Component, OnInit, Injector } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { LoginModel } from "../../shared/viewModel/login.model";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { SettingsService } from "../../core/settings/settings.service";
import { UserProfile } from "../../shared/viewModel/userProfile.model";

@Component({
    selector: "app-lock",
    templateUrl: "./lock.component.html",
    styleUrls: ["./lock.component.scss"],
    providers: [AuthenticationService]
})
export class LockComponent implements OnInit {

    user: UserProfile;
    valForm: FormGroup;

    constructor(public settings: SettingsService,
        fb: FormBuilder,
        public injector: Injector,
        private authService: AuthenticationService,
        private route: ActivatedRoute,
        private router: Router) {

        this.valForm = fb.group({
            "password": [null, Validators.required]
        });

    }

    async submitForm($ev, value: any) {
        $ev.preventDefault();
        let login = new LoginModel(this.user.userName, this.valForm.get("password").value, true);
        let loginResult = await this.authService.auth(login).toPromise();
        if (loginResult.data.signInResult.succeeded) {
            let returnUrl = this.route.snapshot.queryParams["returnUrl"];
            this.settings.setProfile(loginResult.data.profile);
            if (returnUrl != null)
                this.router.navigateByUrl(returnUrl);
            else
                this.router.navigate(["/home"]);
        }
    }

    ngOnInit() {
        this.getProfile();
    }

    private async getProfile() {
        this.user = await this.settings.getProfile().toPromise();
    }

}
