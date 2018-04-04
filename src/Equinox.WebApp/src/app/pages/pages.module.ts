import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { DndModule } from "ng2-dnd";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { AlertModule } from "ngx-bootstrap/alert";
import { TextMaskModule } from "angular2-text-mask";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { Error404Component } from "./error404/error404.component";
import { LockComponent } from "./lock/lock.component";
import { RecoverComponent } from "./recover/recover.component";
import { ResetPasswordComponent } from "./reset-password/reset-password.component";

const routes: Routes = [
    { path: "", redirectTo: "sign-in", pathMatch: "full" },
    { path: "sign-in", component: LoginComponent },
    { path: "register", component: RegisterComponent },
    { path: "not-found", component: Error404Component },
    { path: "lock", component: LockComponent },
    { path: "recover", component: RecoverComponent },
    { path: "reset-password", component: ResetPasswordComponent },
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(routes),
        DndModule.forRoot(),
        AlertModule.forRoot(),
        TextMaskModule,
    ],
    declarations: [
        LoginComponent,
        RegisterComponent,
        Error404Component,
        LockComponent,
        RecoverComponent,
        ResetPasswordComponent
    ],
    exports: [
        RouterModule
    ]
})
export class PagesModule { }
