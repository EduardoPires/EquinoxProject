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

@Component({
    selector: "app-register",
    templateUrl: "./register.component.html",
    styleUrls: ["./register.component.scss"],
    providers: [AuthenticationService]
})
export class RegisterComponent implements OnInit, OnDestroy {

    private valForm: FormGroup;
    private passwordForm: FormGroup;
    private googleForm: FormGroup;
    private newUser: RegisterModel;
    public errors: Array<string>;
    public telefoneMask: Array<string | RegExp>;

    public showButtonLoading: boolean;
    private externalAccessSubscription: Subscription;

    private userExistsSubject: Subject<string> = new Subject<string>();
    private emailExistsSubject: Subject<string> = new Subject<string>();

    constructor(public settings: SettingsService,
        fb: FormBuilder,
        private registerService: AuthenticationService,
        private router: Router,
        private route: ActivatedRoute) {

        this.telefoneMask = ["+", /[1-9]/, /[1-9]/, " ", "(", /[1-9]/, /[1-9]/, ")", " ", /\d/, "-", /\d/, /\d/, /\d/, /\d/, "-", /\d/, /\d/, /\d/, /\d/];
        let password = new FormControl("", Validators.compose([Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/g)]));

        let certainPassword = new FormControl("", CustomValidators.equalTo(password));

        this.passwordForm = fb.group({
            "password": password,
            "confirmPassword": certainPassword
        });

        this.valForm = fb.group({
            "email": [null, Validators.compose([Validators.required, CustomValidators.email])],
            "accountagreed": [null, Validators.required],
            "passwordGroup": this.passwordForm,
            "telephone": [null, Validators.required],
            "username": [null, Validators.compose([Validators.required, CustomValidators.username])],
            "name": [null, Validators.required]
        });

        this.googleForm = fb.group({
            provider: ["", Validators.required]
        });
    }


    public ngOnDestroy() {
        this.externalAccessSubscription.unsubscribe();
    }

    public ngOnInit() {
        this.newUser = new RegisterModel();
        this.externalAccessSubscription = this.route
            .queryParams
            .subscribe(params => {
                // Defaults to 0 if no query param provided.
                console.log(params);
                if (params != null)
                    this.setFormData(params.provider, params.external_access_token);
            });
        this.showButtonLoading = false;

        this.userExistsSubject
            .debounceTime(500)
            .switchMap(a => this.registerService.checkUserName(a))
            .subscribe((response: DefaultResponse<boolean>) => {
                if (response.data)
                    this.valForm.controls["username"].setErrors({ "exists": "Username already taken" });
            });

        this.emailExistsSubject
            .debounceTime(500)
            .switchMap(a => this.registerService.checkEmail(a))
            .subscribe((response: DefaultResponse<boolean>) => {
                if (response.data)
                    this.valForm.controls["email"].setErrors({ "exists": "E-mail already taken" });
            });

        this.errors = [];
    }


    public checkIfEmailExists() {
        if (this.valForm.controls["email"].hasError("email"))
            return;

        let value = this.valForm.get("email").value;
        if (value != null && value != "")
            this.emailExistsSubject.next(value);
    }

    public checkIfUniquenameExists() {
        let value = this.valForm.get("username").value;
        if (value != null && value != "")
            this.userExistsSubject.next(value);
    }

    private setFormData(provider: string, accessToken: string) {
        this.newUser.provider = provider;

        if (provider == "Google") {
            this.newUser.externalAccessToken = accessToken;

            // this.registerService.getGoogleUserData(this.newUser.externalAccessToken).subscribe((res: any) => {
            //     this.newUser.imagem = res.picture;
            //     this.valForm.patchValue({ 'username': `${res.given_name}${res.family_name}` });
            //     this.valForm.patchValue({ 'email': res.email });
            //     this.valForm.patchValue({ 'nome': res.name });

            //     this.verificarSeUniqueNameExiste();
            // });
        }

        if (provider == "Facebook") {
            this.newUser.externalAccessToken = accessToken;

            // this.registerService.getFacebookUserData(this.newUser.externalAccessToken).subscribe((res: any) => {
            //     this.valForm.patchValue({ 'nome': res.name });
            //     this.registerService.getFacebookUserPicture(this.newUser.externalAccessToken, res.id).subscribe((picData: any) => {
            //         this.newUser.imagem = picData.data.url;
            //     });
            // });

        }
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
            this.newUser.confirmPassword = this.valForm.get("passwordGroup.password").value;
            this.newUser.password = this.valForm.get("passwordGroup.password").value;
            this.newUser.email = this.valForm.get("email").value;
            this.newUser.telephone = this.valForm.get("telephone").value;
            this.newUser.username = this.valForm.get("username").value;
            this.newUser.name = this.valForm.get("name").value;

            try {

                this.registerService.register(this.newUser).subscribe(
                    registerResult => { if (registerResult.data) this.router.navigate(["/sign-in"]); },
                    response => {
                        this.errors = [];
                        if (response.error.errors != null)
                            response.error.errors.forEach(element => this.errors.push(element));
                        else {
                            this.errors.push("Unknown error while trying to register");
                        }
                        this.showButtonLoading = false;
                    }
                );

            } catch (error) {
                this.errors = [];
                this.errors.push("Unknown error while trying to register");
                this.showButtonLoading = false;
                return Observable.throw("Unknown error while trying to register");
            }
        }
    }

    // ALERT METHOD
    public closeAlert(i: number): void {
        this.errors.splice(i, 1);
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
