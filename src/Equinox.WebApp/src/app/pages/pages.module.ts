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
<<<<<<< HEAD
<<<<<<< HEAD
import { LockComponent } from "./lock/lock.component";
import { RecoverComponent } from "./recover/recover.component";
import { ResetPasswordComponent } from "./reset-password/reset-password.component";
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { LockComponent } from "./lock/lock.component";
import { RecoverComponent } from "./recover/recover.component";
import { ResetPasswordComponent } from "./reset-password/reset-password.component";
>>>>>>> 383c77b... * Recover Password

const routes: Routes = [
    { path: "", redirectTo: "sign-in", pathMatch: "full" },
    { path: "sign-in", component: LoginComponent },
    { path: "register", component: RegisterComponent },
    { path: "not-found", component: Error404Component },
<<<<<<< HEAD
<<<<<<< HEAD
    { path: "lock", component: LockComponent },
    { path: "recover", component: RecoverComponent },
    { path: "reset-password", component: ResetPasswordComponent },
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
    { path: "lock", component: LockComponent },
    { path: "recover", component: RecoverComponent },
    { path: "reset-password", component: ResetPasswordComponent },
>>>>>>> 383c77b... * Recover Password
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
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 383c77b... * Recover Password
        Error404Component,
        LockComponent,
        RecoverComponent,
        ResetPasswordComponent
<<<<<<< HEAD
=======
        Error404Component
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 383c77b... * Recover Password
    ],
    exports: [
        RouterModule
    ]
})
export class PagesModule { }
