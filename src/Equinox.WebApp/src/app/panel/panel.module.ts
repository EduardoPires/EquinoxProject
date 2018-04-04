import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { DndModule } from "ng2-dnd";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { AlertModule } from "ngx-bootstrap/alert";
import { TextMaskModule } from "angular2-text-mask";
import { LayoutComponent } from "../shared/layout/layout.component";
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
import { AuthenticationService } from "../shared/services/authentication.service";
import { AccountManagementService } from "../shared/services/account-management.service";
import { BrowserModule } from "@angular/platform-browser";
import { ToasterService } from "angular2-toaster";
import { IsLoggedInGuard } from "../core/guard/IsLoggedInGuard";
<<<<<<< HEAD
=======
import { PitbullGuard } from "../core/guard/pitbull";
=======
>>>>>>> 383c77b... * Recover Password
import { AuthenticationService } from "../shared/services/authentication.service";
<<<<<<< HEAD
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { AccountManagementService } from "../shared/services/account-management.service";
import { BrowserModule } from "@angular/platform-browser";
import { ToasterService } from "angular2-toaster";
<<<<<<< HEAD
>>>>>>> 86e6256... Daily commit
=======
<<<<<<< HEAD
>>>>>>> 86e6256... Daily commit
=======
import { IsLoggedInGuard } from "../core/guard/IsLoggedInGuard";
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors

const routes: Routes = [
    {
        path: "",
        canActivate: [
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
            IsLoggedInGuard
        ],
        children: [
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "home", loadChildren: "app/panel/home/home.module#HomeModule" },
            { path: "user", loadChildren: "app/panel/user/user.module#UserModule" }
        ]
    },
];

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes),
    ],
    declarations: [
    ],
    providers: [
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
        IsLoggedInGuard,
        AuthenticationService,
        AccountManagementService,
        ToasterService
=======
        PitbullGuard,
<<<<<<< HEAD
        AuthenticationService
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
<<<<<<< HEAD
=======
=======
        IsLoggedInGuard,
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
        IsLoggedInGuard,
>>>>>>> c3e8855... Fixing rebase errors
        AuthenticationService,
        AccountManagementService,
        ToasterService
    ],
    exports: [
        RouterModule
    ]
})
export class PanelModule { }
