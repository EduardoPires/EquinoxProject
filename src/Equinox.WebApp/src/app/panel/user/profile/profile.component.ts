import { Component, OnInit } from "@angular/core";
import { ChangePasswordViewModel } from "../../../shared/viewModel/changePassword.model";
import { SettingsService } from "../../../core/settings/settings.service";
import { AccountManagementService } from "../../../shared/services/account-management.service";
import { ToasterService, ToasterConfig } from "angular2-toaster";
import { UserProfile } from "../../../shared/viewModel/userProfile.model";
import { FileUpload } from "../../../shared/viewModel/fileUpload";


@Component({
    selector: "app-user-profile",
    templateUrl: "./profile.component.html",
    styleUrls: ["./profile.component.scss"]
})
export class ProfileComponent implements OnInit {

    public changingPassword: boolean;
    public uploadingImage: boolean;
    public updatingProfile: boolean;

    public user: UserProfile;
    public ChangePass: ChangePasswordViewModel;
    public errors: Array<string>;

    public toasterconfig: ToasterConfig = new ToasterConfig({
        positionClass: "toast-bottom-right",
        showCloseButton: true
    });

    constructor(
        public settings: SettingsService,
        private accountManagement: AccountManagementService,
        private toasterService: ToasterService) { }

    ngOnInit() {
        this.ChangePass = new ChangePasswordViewModel();
        this.changingPassword = false;
        this.uploadingImage = false;
        this.errors = [];
        this.user = new UserProfile();
        this.settings.getProfile().subscribe(a => this.setUser(a));
    }

    private setUser(user: UserProfile) {
        this.user = user;
        this.user.bio = this.treatNull(this.user.bio);
        this.user.company = this.treatNull(this.user.company);
        this.user.jobTitle = this.treatNull(this.user.jobTitle);
        this.user.name = this.treatNull(this.user.name);
        this.user.url = this.treatNull(this.user.url);
    }

    public async ChangePassword() {
        this.errors = [];
        if (!this.isValid())
            return;

        this.changingPassword = true;

        let result = await this.accountManagement.changePassword(this.ChangePass).toPromise();

        if (result.data.succeeded) {
            this.ChangePass = new ChangePasswordViewModel();
            this.toasterService.pop("success", "Success", "Password changed successful");
        }
        else {
            this.toasterService.pop("error", "Error", "See the errors above");
            result.data.errors.forEach(e => this.errors.push(e.description));
        }
        this.changingPassword = false;
    }

    public DeleteAccount() {
        this.toasterService.pop("warning", "Error", "Just a grocery item");
    }

    public handleFileInput(files: FileList) {
        this.uploadingImage = true;

        let fileToUpload = files.item(0);
        let reader = new FileReader();
        let fileData: FileUpload;
        reader.readAsDataURL(fileToUpload);
        reader.onload = () => {
            fileData = new FileUpload(
                fileToUpload.name,
                fileToUpload.type,
                reader.result.split(",")[1]
            );

            this.accountManagement.updateImageFile(fileData).subscribe(
                s => {
                    this.toasterService.pop("success", "Success", "Picture changed successful");
                    this.user.picture = s.data;
                    this.uploadingImage = false;
                },
                errors => {
                    this.toasterService.pop("error", "Error", "See the errors above");
                    errors.errors.forEach(e => this.errors.push(e.description));
                    this.uploadingImage = false;
                }
            );
        };
    }

    public async UpdateSettings() {
        this.updatingProfile = true;
        let result = await this.accountManagement.updateProfile(this.user).toPromise();
        if (result.data.succeeded) {
            this.settings.setProfile(this.user);
            this.toasterService.pop("success", "Success", "Profile updated successful");
        } else {
            this.toasterService.pop("error", "Error", "Try again later");
        }

        this.updatingProfile = false;
    }

    private isValid() {
        let pattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/g;
        if (this.ChangePass.NewPassword == "" || this.ChangePass.NewPassword == null)
            this.errors.push("Invalid password");

        if (!pattern.test(this.ChangePass.NewPassword))
            this.errors.push("Password must have a uppercase, lowercase, special character and number and a minimum lenght of 8 chars");

        if (this.ChangePass.NewPassword != this.ChangePass.ConfirmPassword)
            this.errors.push("Pass must be equal.");

        return this.errors.length == 0;
    }

    private treatNull(data: string) {
        if (data == null)
            return "";

        return data;
    }
}
