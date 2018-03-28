import { Component, OnInit, OnDestroy } from "@angular/core";
declare var $: any;

import { SettingsService } from "../../../core/settings/settings.service";
import { ThemesService } from "../../../core/themes/themes.service";
import { TranslatorService } from "../../../core/translator/translator.service";

@Component({
    selector: "app-offsidebar",
    templateUrl: "./offsidebar.component.html",
    styleUrls: ["./offsidebar.component.scss"]
})
export class OffsidebarComponent implements OnInit, OnDestroy {

    currentTheme: any;
    selectedLanguage: string;
    clickEvent = "click.offsidebar";
    $doc: any = null;

    constructor(public settings: SettingsService, public themes: ThemesService, public translator: TranslatorService) {
        this.currentTheme = themes.getDefaultTheme();
        this.selectedLanguage = this.getLangs()[0].code;
    }

    ngOnInit() {
        this.anyClickClose();
    }

    setTheme() {
        this.themes.setTheme(this.currentTheme);
    }

    getLangs() {
        return this.translator.getAvailableLanguages();
    }

    setLang(value) {
        this.translator.useLanguage(value);
    }

    anyClickClose() {
        this.$doc = $(document).on(this.clickEvent, (e) => {
            if (!$(e.target).parents(".offsidebar").length) {
                this.settings.layout.offsidebarOpen = false;
            }
        });
    }

    ngOnDestroy() {
        if (this.$doc)
            this.$doc.off(this.clickEvent);
    }
}
