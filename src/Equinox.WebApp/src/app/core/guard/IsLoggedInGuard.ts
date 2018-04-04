import { CanActivate, Router } from "@angular/router";
import { Injectable } from "@angular/core";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { AccountManagementService } from "../../shared/services/account-management.service";
import { SettingsService } from "../settings/settings.service";
import { Observable } from "rxjs/Observable";
import { of } from "rxjs/observable/of";

@Injectable()
export class IsLoggedInGuard implements CanActivate {

  constructor(
    private authService: AuthenticationService,
    private router: Router) { }

  async canActivate() {
    try {
      let canAccess = await this.authService.isLoggedIn().flatMap(a => of(a.data)).toPromise();
      if (!canAccess) {
        this.router.navigate(["/"]);
      }
      return canAccess;
    } catch (error) {
      this.router.navigate(["/"]);
      return false;
    }

  }

}
