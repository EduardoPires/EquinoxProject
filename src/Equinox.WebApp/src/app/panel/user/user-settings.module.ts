import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SharedModule } from "../../shared/shared.module";
import { DndModule } from "ng2-dnd";
import { ProfileComponent } from "./profile/profile.component";

const routes: Routes = [
    { path: "", redirectTo: "profile", pathMatch: "full" },
    { path: "profile", component: ProfileComponent },
];

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild(routes),
        DndModule.forRoot(),
    ],
    declarations: [
        ProfileComponent
    ],
    exports: [
        RouterModule
    ]
})
export class UserModule { }
