import { Component, OnInit } from "@angular/core";
import { SettingsService } from "../../core/settings/settings.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { CustomValidators } from "ng2-validation";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { Router, ActivatedRoute } from "@angular/router";
import { LoginModel } from "../../shared/viewModel/login.model";
import { Subscription } from "rxjs/Subscription";

@Component({
    selector: "app-login",
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.scss"],
    providers: [AuthenticationService]
})
export class LoginComponent implements OnInit {

    valForm: FormGroup;
    public errors: Array<string>;

    constructor(
        public settings: SettingsService,
        fb: FormBuilder,
        private authService: AuthenticationService,
        private router: Router,
        private route: ActivatedRoute) {

        this.valForm = fb.group({
<<<<<<< HEAD
<<<<<<< HEAD
            "username": [null, Validators.required],
=======
            "email": [null, Validators.compose([Validators.required, CustomValidators.email])],
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
            "username": [null, Validators.required],
>>>>>>> 86e6256... Daily commit
            "password": [null, Validators.required],
            "rememberMe": [null, Validators.required]
        });
        this.errors = [];
    }

    submitForm($ev, value: any) {
        this.errors = [];
        $ev.preventDefault();
        for (let c in this.valForm.controls) {
            this.valForm.controls[c].markAsTouched();
        }
        let rememberMe = this.valForm.get("rememberMe").value == null ? false : this.valForm.get("rememberMe").value;
<<<<<<< HEAD
<<<<<<< HEAD
        let login = new LoginModel(this.valForm.get("username").value, this.valForm.get("password").value, rememberMe);
        this.authService.auth(login).subscribe(
            loginResult => {
                if (loginResult.data.signInResult.succeeded) {
                    let returnUrl = this.route.snapshot.queryParams["returnUrl"];
                    this.settings.setProfile(loginResult.data.profile);
=======
        let login = new LoginModel(this.valForm.get("email").value, this.valForm.get("password").value, rememberMe);
=======
        let login = new LoginModel(this.valForm.get("username").value, this.valForm.get("password").value, rememberMe);
>>>>>>> 86e6256... Daily commit
        this.authService.auth(login).subscribe(
            loginResult => {
                if (loginResult.data.signInResult.succeeded) {
                    let returnUrl = this.route.snapshot.queryParams["returnUrl"];
<<<<<<< HEAD
<<<<<<< HEAD

>>>>>>> fd1205c... Bug fix while creating new Db.
=======
                    this.settings.user = loginResult.data.profile;
>>>>>>> 35c7771... daily commit
=======
                    this.settings.setProfile(loginResult.data.profile);
>>>>>>> 86e6256... Daily commit
                    if (returnUrl != null)
                        this.router.navigateByUrl(returnUrl);
                    else
                        this.router.navigate(["/home"]);
                }
            },
            response => {
                this.errors = [];
                response.error.errors.forEach(element => this.errors.push(element));
            }
        );
    }

    ngOnInit() {
        console.log(this.route.snapshot.queryParams);
    }

}
