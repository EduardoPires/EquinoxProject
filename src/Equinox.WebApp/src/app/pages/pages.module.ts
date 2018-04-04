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
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
import { LockComponent } from "./lock/lock.component";
import { RecoverComponent } from "./recover/recover.component";
import { ResetPasswordComponent } from "./reset-password/reset-password.component";
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
<<<<<<< HEAD
=======
=======
import { LockComponent } from "./lock/lock.component";
import { RecoverComponent } from "./recover/recover.component";
import { ResetPasswordComponent } from "./reset-password/reset-password.component";
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
import { LockComponent } from "./lock/lock.component";
import { RecoverComponent } from "./recover/recover.component";
import { ResetPasswordComponent } from "./reset-password/reset-password.component";
>>>>>>> c3e8855... Fixing rebase errors

const routes: Routes = [
    { path: "", redirectTo: "sign-in", pathMatch: "full" },
    { path: "sign-in", component: LoginComponent },
    { path: "register", component: RegisterComponent },
    { path: "not-found", component: Error404Component },
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
    { path: "lock", component: LockComponent },
    { path: "recover", component: RecoverComponent },
    { path: "reset-password", component: ResetPasswordComponent },
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
<<<<<<< HEAD
=======
=======
    { path: "lock", component: LockComponent },
    { path: "recover", component: RecoverComponent },
    { path: "reset-password", component: ResetPasswordComponent },
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
    { path: "lock", component: LockComponent },
    { path: "recover", component: RecoverComponent },
    { path: "reset-password", component: ResetPasswordComponent },
>>>>>>> c3e8855... Fixing rebase errors
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
        Error404Component,
        LockComponent,
        RecoverComponent,
        ResetPasswordComponent
<<<<<<< HEAD
<<<<<<< HEAD
=======
        Error404Component
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
<<<<<<< HEAD
=======
        Error404Component
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
    ],
    exports: [
        RouterModule
    ]
})
export class PagesModule { }
