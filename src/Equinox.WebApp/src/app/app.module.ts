import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"; // this is needed!
import { NgModule } from "@angular/core";
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from "@angular/common/http";
import { TranslateService, TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";

import { AppComponent } from "./app.component";

import { CoreModule } from "./core/core.module";
import { LayoutModule } from "./shared/layout/layout.module";
import { SharedModule } from "./shared/shared.module";
import { RoutesModule } from "./app.routing.module";
import { WithCredentialInterceptor } from "./core/interceptors/withCredential.interceptor";

// https://github.com/ocombe/ng2-translate/issues/218
export function createTranslateLoader(http: HttpClient) {
    return new TranslateHttpLoader(http, "./assets/i18n/", ".json");
}

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
        ...dev,
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
