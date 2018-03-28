import { Component, OnInit } from "@angular/core";
import { SettingsService } from "../../core/settings/settings.service";

@Component({
  selector: "app-error500",
  templateUrl: "./error500.component.html",
  styleUrls: ["./error500.component.scss"]
})
export class Error500Component implements OnInit {

  constructor(public settings: SettingsService) { }

  ngOnInit() {
  }

}
