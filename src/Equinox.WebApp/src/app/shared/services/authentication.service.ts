import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import { Observable } from "rxjs/Observable";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { RegisterModel } from "../viewModel/register.model";
import { DefaultResponse } from "../viewModel/defaultResponse.model";
import { LoginModel } from "../viewModel/login.model";
import { SignInResult } from "../viewModel/signInResult.model";

@Injectable()
export class AuthenticationService {


    constructor(private http: HttpClient) {
        // set token if saved in local storage
    }


    public register(register: RegisterModel): Observable<DefaultResponse<RegisterModel>> {
        return this.http.post<DefaultResponse<RegisterModel>>(environment.API_URL + "v1/account/register", register);
    }

    public auth(register: LoginModel): Observable<DefaultResponse<SignInResult>> {
        return this.http.post<DefaultResponse<SignInResult>>(environment.API_URL + "v1/account/login", register);
    }

    public checkUserName(userName: string): Observable<DefaultResponse<boolean>> {
        let params = {
            username: userName
        };
        return this.http.get<DefaultResponse<boolean>>(environment.API_URL + "v1/account/checkUsername", { params: params });
    }
}
