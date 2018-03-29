import { Component, OnInit } from "@angular/core";


@Component({
    selector: "app-home",
    templateUrl: "./profile.component.html",
    styleUrls: ["./profile.component.scss"]
})
export class ProfileComponent implements OnInit {

    techs: Array<string> = [".NET Core", "ASP.NET Core 1.1", "ASP.NET Identity", "MVC Core", "EF Core", "Dapper", "AutoMapper", "FluentValidator"];
    design: Array<string> = [
            "Full architecture with responsibility separation concerns, SOLID and Clean Code",
            "DDD Concepts - Layers and Domain Model Pattern",
            "CQRS - Command Query Responsibility Segregation",
            "Event Sourcing"];

    constructor() { }

    ngOnInit() {
    }
}
