import { CanActivate } from "@angular/router";
import { Injectable } from "@angular/core";
import { AuthenticationService } from "../../shared/services/authentication.service";

@Injectable()
export class PitbullGuard implements CanActivate {

  constructor(private authService: AuthenticationService) { }

  canActivate() {
    console.log("Howl howl");
    return true;
  }
}
