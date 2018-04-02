import { CanActivate, Router } from "@angular/router";
import { Injectable } from "@angular/core";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { AccountManagementService } from "../../shared/services/account-management.service";
import { SettingsService } from "../settings/settings.service";
import { Observable } from "rxjs/Observable";
import { of } from "rxjs/observable/of";

@Injectable()
export class PitbullGuard implements CanActivate {

  constructor(public settings: SettingsService,
    private accountManagementService: AccountManagementService,
    private router: Router) { }

  canActivate() {
    return this.settings.getProfile().flatMap(a => of(true));
  }

}
