import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import { Observable } from "rxjs/Observable";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { RegisterModel } from "../viewModel/register.model";
import { DefaultResponse } from "../viewModel/defaultResponse.model";
import { LoginModel } from "../viewModel/login.model";
import { SignInResult } from "../viewModel/signInResult.model";
<<<<<<< HEAD
<<<<<<< HEAD
import { LoginResult } from "../viewModel/loginResult.model";
import { ResetPasswordModel } from "../viewModel/reset-password.model";
import { UserManagementResult } from "../viewModel/userManagementResult.model";
<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { LoginResult } from "../viewModel/loginResult.model";
>>>>>>> 35c7771... daily commit
=======
>>>>>>> 383c77b... * Recover Password

@Injectable()
export class AuthenticationService {

<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 383c77b... * Recover Password
    constructor(private http: HttpClient) {
        // set token if saved in local storage
    }

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 383c77b... * Recover Password
    public resetPassword(resetPass: ResetPasswordModel): Observable<DefaultResponse<UserManagementResult>> {
        return this.http.post<DefaultResponse<UserManagementResult>>(environment.API_URL + "v1/account/reset-password", resetPass);
    }

    public recoverPassword(email: string): Observable<DefaultResponse<boolean>> {
        return this.http.post<DefaultResponse<boolean>>(environment.API_URL + "v1/account/forgot-password", {email: email});
    }
    public isLoggedIn(): Observable<DefaultResponse<boolean>> {
        return this.http.get<DefaultResponse<boolean>>(environment.API_URL + "v1/account/is-logged-in");
    }
    public logout(): Observable<DefaultResponse<boolean>> {
        return this.http.post<DefaultResponse<boolean>>(environment.API_URL + "v1/account/logout", null);
    }
<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 383c77b... * Recover Password

    public register(register: RegisterModel): Observable<DefaultResponse<RegisterModel>> {
        return this.http.post<DefaultResponse<RegisterModel>>(environment.API_URL + "v1/account/register", register);
    }

<<<<<<< HEAD
<<<<<<< HEAD
    public auth(register: LoginModel): Observable<DefaultResponse<LoginResult>> {
        return this.http.post<DefaultResponse<LoginResult>>(environment.API_URL + "v1/account/login", register);
=======
    public auth(register: LoginModel): Observable<DefaultResponse<SignInResult>> {
        return this.http.post<DefaultResponse<SignInResult>>(environment.API_URL + "v1/account/login", register);
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
    public auth(register: LoginModel): Observable<DefaultResponse<LoginResult>> {
        return this.http.post<DefaultResponse<LoginResult>>(environment.API_URL + "v1/account/login", register);
>>>>>>> 35c7771... daily commit
    }

    public checkUserName(userName: string): Observable<DefaultResponse<boolean>> {
        let params = {
            username: userName
        };
        return this.http.get<DefaultResponse<boolean>>(environment.API_URL + "v1/account/checkUsername", { params: params });
    }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 86e6256... Daily commit

    public checkEmail(email: string): Observable<DefaultResponse<boolean>> {
        let params = {
            email: email
        };
        return this.http.get<DefaultResponse<boolean>>(environment.API_URL + "v1/account/checkEmail", { params: params });
    }
<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 86e6256... Daily commit
}
