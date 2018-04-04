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
import { AuthenticationService } from "../shared/services/authentication.service";
import { AccountManagementService } from "../shared/services/account-management.service";
import { BrowserModule } from "@angular/platform-browser";
import { ToasterService } from "angular2-toaster";
import { IsLoggedInGuard } from "../core/guard/IsLoggedInGuard";
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
import { IsLoggedInGuard } from "../core/guard/IsLoggedInGuard";
>>>>>>> 383c77b... * Recover Password

const routes: Routes = [
    {
        path: "",
        canActivate: [
<<<<<<< HEAD
<<<<<<< HEAD
            IsLoggedInGuard
        ],
        children: [
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "home", loadChildren: "app/panel/home/home.module#HomeModule" },
            { path: "user", loadChildren: "app/panel/user/user.module#UserModule" }
=======
            PitbullGuard
=======
            IsLoggedInGuard
>>>>>>> 383c77b... * Recover Password
        ],
        children: [
            { path: "", redirectTo: "home", pathMatch: "full" },
<<<<<<< HEAD
            { path: "home", loadChildren: "app/panel/home/home.module#HomeModule" }
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
            { path: "home", loadChildren: "app/panel/home/home.module#HomeModule" },
            { path: "user", loadChildren: "app/panel/user/user.module#UserModule" }
>>>>>>> 226bd07... Daily commit
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
=======
        IsLoggedInGuard,
>>>>>>> 383c77b... * Recover Password
        AuthenticationService,
        AccountManagementService,
        ToasterService
>>>>>>> 86e6256... Daily commit
    ],
    exports: [
        RouterModule
    ]
})
export class PanelModule { }
