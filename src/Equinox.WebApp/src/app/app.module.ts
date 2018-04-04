import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"; // this is needed!
import { NgModule } from "@angular/core";
<<<<<<< HEAD
<<<<<<< HEAD
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from "@angular/common/http";
=======
import { HttpClientModule, HttpClient } from "@angular/common/http";
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from "@angular/common/http";
>>>>>>> 86e6256... Daily commit
import { TranslateService, TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";

import { AppComponent } from "./app.component";

import { CoreModule } from "./core/core.module";
import { LayoutModule } from "./shared/layout/layout.module";
import { SharedModule } from "./shared/shared.module";
import { RoutesModule } from "./app.routing.module";
<<<<<<< HEAD
<<<<<<< HEAD
import { WithCredentialInterceptor } from "./core/interceptors/withCredential.interceptor";
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { WithCredentialInterceptor } from "./core/interceptors/withCredential.interceptor";
>>>>>>> 86e6256... Daily commit

// https://github.com/ocombe/ng2-translate/issues/218
export function createTranslateLoader(http: HttpClient) {
    return new TranslateHttpLoader(http, "./assets/i18n/", ".json");
}

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 86e6256... Daily commit
// import dev only modules
let dev = [
    {
        provide: HTTP_INTERCEPTORS,
        useClass: WithCredentialInterceptor,
        multi: true
    }
];

// if production clear dev imports and set to prod mode
if (process.env.NODE_ENV === "production") {
    dev = [];
}

<<<<<<< HEAD
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
>>>>>>> 86e6256... Daily commit
@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        HttpClientModule,
        BrowserAnimationsModule, // required for ng2-tag-input
        CoreModule,
        LayoutModule,
        SharedModule.forRoot(),
        RoutesModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: (createTranslateLoader),
                deps: [HttpClient]
            }
        })
    ],
    providers: [
<<<<<<< HEAD
<<<<<<< HEAD
        ...dev,
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
        ...dev,
>>>>>>> 86e6256... Daily commit
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
