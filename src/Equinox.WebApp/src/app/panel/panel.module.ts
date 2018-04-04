import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { DndModule } from "ng2-dnd";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { AlertModule } from "ngx-bootstrap/alert";
import { TextMaskModule } from "angular2-text-mask";
import { LayoutComponent } from "../shared/layout/layout.component";
import { AuthenticationService } from "../shared/services/authentication.service";
import { AccountManagementService } from "../shared/services/account-management.service";
import { BrowserModule } from "@angular/platform-browser";
import { ToasterService } from "angular2-toaster";
import { IsLoggedInGuard } from "../core/guard/IsLoggedInGuard";

const routes: Routes = [
    {
        path: "",
        canActivate: [
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
        IsLoggedInGuard,
        AuthenticationService,
        AccountManagementService,
        ToasterService
    ],
    exports: [
        RouterModule
    ]
})
export class PanelModule { }
