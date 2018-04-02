import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ChangePasswordViewModel } from "../viewModel/changePassword.model";
import { Observable } from "rxjs/Observable";
import { DefaultResponse } from "../viewModel/defaultResponse.model";
import { environment } from "../../../environments/environment";
import { UserManagementResult } from "../viewModel/changePasswordResult.model";
import { UserProfile } from "../viewModel/userProfile.model";
import { FileUpload } from "../viewModel/fileUpload";

@Injectable()
export class AccountManagementService {
    constructor(private http: HttpClient) {
        // set token if saved in local storage
    }


    public changePassword(changePass: ChangePasswordViewModel): Observable<DefaultResponse<UserManagementResult>> {
        return this.http.post<DefaultResponse<UserManagementResult>>(environment.API_URL + "v1/account-management/change-password", changePass);
    }

    public updateProfile(profile: UserProfile): Observable<DefaultResponse<string>> {
        return this.http.post<DefaultResponse<string>>(environment.API_URL + "v1/account-management/update-profile", profile);
    }

    public updateImageFile(fileToUpload: FileUpload): Observable<DefaultResponse<string>> {
        const endpoint = "v1/account-management/update-picture";
        return this.http.post<DefaultResponse<string>>(environment.API_URL + endpoint, fileToUpload);
    }

}
