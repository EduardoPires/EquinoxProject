import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { DndModule } from "ng2-dnd";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { AlertModule } from "ngx-bootstrap/alert";
import { TextMaskModule } from "angular2-text-mask";
import { LayoutComponent } from "../shared/layout/layout.component";
import { PitbullGuard } from "../core/guard/pitbull";
import { AuthenticationService } from "../shared/services/authentication.service";

const routes: Routes = [
    {
        path: "",
        canActivate: [
            PitbullGuard
        ],
        children: [
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "home", loadChildren: "app/panel/home/home.module#HomeModule" }
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
        PitbullGuard,
        AuthenticationService
    ],
    exports: [
        RouterModule
    ]
})
export class PanelModule { }
