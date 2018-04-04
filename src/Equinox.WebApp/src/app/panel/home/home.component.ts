import { Component, OnInit } from "@angular/core";


@Component({
    selector: "app-home",
    templateUrl: "./home.component.html",
    styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
    techs: Array<string> = [".NET Core", "ASP.NET Core 2.0", "ASP.NET Identity", "MVC Core", "EF Core", "Dapper", "AutoMapper", "FluentValidator"];
=======
    techs: Array<string> = [".NET Core", "ASP.NET Core 1.1", "ASP.NET Identity", "MVC Core", "EF Core", "Dapper", "AutoMapper", "FluentValidator"];
>>>>>>> fd1205c... Bug fix while creating new Db.
<<<<<<< HEAD
=======
=======
    techs: Array<string> = [".NET Core", "ASP.NET Core 2.0", "ASP.NET Identity", "MVC Core", "EF Core", "Dapper", "AutoMapper", "FluentValidator"];
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
    techs: Array<string> = [".NET Core", "ASP.NET Core 2.0", "ASP.NET Identity", "MVC Core", "EF Core", "Dapper", "AutoMapper", "FluentValidator"];
>>>>>>> c3e8855... Fixing rebase errors
    design: Array<string> = [
            "Full architecture with responsibility separation concerns, SOLID and Clean Code",
            "DDD Concepts - Layers and Domain Model Pattern",
            "CQRS - Command Query Responsibility Segregation",
            "Event Sourcing"];

    constructor() { }

    ngOnInit() {
    }

}
