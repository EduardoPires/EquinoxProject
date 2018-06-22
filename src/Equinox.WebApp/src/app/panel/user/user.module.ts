import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SharedModule } from "../../shared/shared.module";
import { DndModule } from "ng2-dnd";
import { ProfileComponent } from "./profile/profile.component";
import { TreeModule } from "angular-tree-component";
import { AgmCoreModule } from "@agm/core";
import { NgxSelectModule } from "ngx-select-ex";

const routes: Routes = [
    { path: "", redirectTo: "profile", pathMatch: "full" },
    { path: "profile", component: ProfileComponent },
];

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes),
        DndModule.forRoot(),
        TreeModule,
        AgmCoreModule.forRoot({
            apiKey: "AIzaSyBNs42Rt_CyxAqdbIBK0a5Ut83QiauESPA"
        }),
        NgxSelectModule
    ],
    declarations: [
        ProfileComponent
    ],
    exports: [
        RouterModule
    ]
})
export class UserModule { }
