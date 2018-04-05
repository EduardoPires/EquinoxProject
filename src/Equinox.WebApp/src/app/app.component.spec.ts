/* tslint:disable:no-unused-variable */

import { TestBed, async} from "@angular/core/testing";
import { AppComponent } from "./app.component";
import { TranslateModule } from "@ngx-translate/core";

import { CoreModule } from "./core/core.module";
import { LayoutModule } from "./shared/layout/layout.module";
import { SharedModule } from "./shared/shared.module";
import { APP_BASE_HREF } from "@angular/common";
import { RoutesModule } from "./app.routing.module";
import { HttpClientModule } from "@angular/common/http";

describe("App: Equinox", () => {
    beforeEach(() => {

        jasmine.DEFAULT_TIMEOUT_INTERVAL = 60000;

        TestBed.configureTestingModule({
            declarations: [
                AppComponent
            ],
            imports: [
                HttpClientModule,
                TranslateModule.forRoot(),
                CoreModule,
                LayoutModule,
                SharedModule,
                RoutesModule
            ],
            providers: [
                { provide: APP_BASE_HREF, useValue: "/" }
            ]
        });
    });

    it("should create the app", async(() => {
        let fixture = TestBed.createComponent(AppComponent);
        let app = fixture.debugElement.componentInstance;
        expect(app).toBeTruthy();
    }));

});
