import { Injectable } from "@angular/core";
<<<<<<< HEAD
<<<<<<< HEAD
import { UserProfile } from "../../shared/viewModel/userProfile.model";
import { DefaultResponse } from "../../shared/viewModel/defaultResponse.model";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { of } from "rxjs/observable/of";

<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { UserProfile } from "../../shared/viewModel/userProfile.model";
>>>>>>> c0e4a03... adding some files
=======
>>>>>>> 86e6256... Daily commit
declare var $: any;

@Injectable()
export class SettingsService {

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private user: UserProfile;
    public app: any;
    public layout: any;

    constructor(private http: HttpClient) {

=======
    public user: any;
=======
    public user: UserProfile;
>>>>>>> c0e4a03... adding some files
=======
    private user: UserProfile;
>>>>>>> 86e6256... Daily commit
    public app: any;
    public layout: any;

    constructor(private http: HttpClient) {

<<<<<<< HEAD
        // User Settings
        // -----------------------------------
        this.user = {
            name: "John",
            job: "ng-developer",
            picture: "assets/img/user/02.jpg"
        };
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 86e6256... Daily commit

        // App Settings
        // -----------------------------------
        this.app = {
            name: "Equinox",
            description: "Equinox Project WebApp - Angular 5",
            year: ((new Date()).getFullYear())
        };

        // Layout Settings
        // -----------------------------------
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 383c77b... * Recover Password
        let savedLayout = localStorage.getItem("LayoutSettings");
        if (savedLayout == null)
            this.layout = {
                isFixed: true,
                isCollapsed: false,
                isBoxed: true,
                isRTL: false,
                horizontal: false,
                isFloat: false,
                asideHover: false,
                theme: null,
                asideScrollbar: false,
                isCollapsedText: false,
                useFullLayout: false,
                hiddenFooter: false,
                offsidebarOpen: false,
                asideToggled: false,
                viewAnimation: "ng-fadeInUp"
            };
        else {
            this.layout = JSON.parse(savedLayout);
            this.layout.offsidebarOpen = false;
        }
    }
<<<<<<< HEAD

    public saveLayout($event) {
        localStorage.setItem("LayoutSettings", JSON.stringify(this.layout));
    }

    public getProfile(): Observable<UserProfile> {

        if (this.user == null)
            return this.getUserFromApi().debounceTime(5000);
        else
            return of(this.user);
    }

    private getUserFromApi() {
        return this.http.get<DefaultResponse<UserProfile>>(environment.API_URL + "v1/account-management/profile").map(a => {
            if (a.success) {
                if (a.data.picture == null)
                    a.data.picture = "assets/img/user/13.jpg";
                this.user = a.data;
            }
            return a.data;
        });
    }

    public setProfile(user: UserProfile) {
        if (user.picture == null)
            user.picture = "assets/img/user/13.jpg";
        this.user = user;
    }

    public getAppSetting(name) {
        return name ? this.app[name] : this.app;
    }
    public getUserSetting(name) {
        return name ? this.user[name] : this.user;
    }
    public getLayoutSetting(name) {
        return name ? this.layout[name] : this.layout;
    }

    public setAppSetting(name, value) {
        if (typeof this.app[name] !== "undefined")
            this.app[name] = value;
    }
    public setUserSetting(name, value) {
        if (typeof this.user[name] !== "undefined")
            this.user[name] = value;
    }
    public setLayoutSetting(name, value) {
=======
        this.layout = {
            isFixed: true,
            isCollapsed: false,
            isBoxed: false,
            isRTL: false,
            horizontal: false,
            isFloat: false,
            asideHover: false,
            theme: null,
            asideScrollbar: false,
            isCollapsedText: false,
            useFullLayout: false,
            hiddenFooter: false,
            offsidebarOpen: false,
            asideToggled: false,
            viewAnimation: "ng-fadeInUp"
        };
=======
>>>>>>> 383c77b... * Recover Password

    public saveLayout($event) {
        localStorage.setItem("LayoutSettings", JSON.stringify(this.layout));
    }

    public getProfile(): Observable<UserProfile> {

        if (this.user == null)
            return this.getUserFromApi().debounceTime(5000);
        else
            return of(this.user);
    }

    private getUserFromApi() {
        return this.http.get<DefaultResponse<UserProfile>>(environment.API_URL + "v1/account-management/profile").map(a => {
            if (a.success) {
                if (a.data.picture == null)
                    a.data.picture = "assets/img/user/13.jpg";
                this.user = a.data;
            }
            return a.data;
        });
    }

    public setProfile(user: UserProfile) {
        if (user.picture == null)
            user.picture = "assets/img/user/13.jpg";
        this.user = user;
    }

    public getAppSetting(name) {
        return name ? this.app[name] : this.app;
    }
    public getUserSetting(name) {
        return name ? this.user[name] : this.user;
    }
    public getLayoutSetting(name) {
        return name ? this.layout[name] : this.layout;
    }

    public setAppSetting(name, value) {
        if (typeof this.app[name] !== "undefined")
            this.app[name] = value;
    }
    public setUserSetting(name, value) {
        if (typeof this.user[name] !== "undefined")
            this.user[name] = value;
    }
<<<<<<< HEAD
    setLayoutSetting(name, value) {
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
    public setLayoutSetting(name, value) {
>>>>>>> 86e6256... Daily commit
        if (typeof this.layout[name] !== "undefined")
            return this.layout[name] = value;
    }

<<<<<<< HEAD
<<<<<<< HEAD
    public toggleLayoutSetting(name) {
=======
    toggleLayoutSetting(name) {
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
    public toggleLayoutSetting(name) {
>>>>>>> 86e6256... Daily commit
        return this.setLayoutSetting(name, !this.getLayoutSetting(name));
    }

}
