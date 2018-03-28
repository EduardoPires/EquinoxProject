import { NgModule, Optional, SkipSelf } from "@angular/core";

import { SettingsService } from "./settings/settings.service";
import { ThemesService } from "./themes/themes.service";
import { TranslatorService } from "./translator/translator.service";
import { MenuService } from "./menu/menu.service";

import { throwIfAlreadyLoaded } from "./module-import-guard";

@NgModule({
    imports: [
    ],
    providers: [
        SettingsService,
        ThemesService,
        TranslatorService,
        MenuService
    ],
    declarations: [
    ],
    exports: [
    ]
})
export class CoreModule {
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, "CoreModule");
    }
}
