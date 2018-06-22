import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";

@Injectable()
export class TranslatorService {

    private defaultLanguage: string = "en";

    private availablelangs = [
        { code: "en", text: "English" },
        { code: "es_AR", text: "Spanish" }
    ];

    constructor(public translate: TranslateService) {

        if (!translate.getDefaultLang())
            translate.setDefaultLang(this.defaultLanguage);

        this.useLanguage();

    }

    useLanguage(lang: string = null) {
        this.translate.use(lang || this.translate.getDefaultLang());
    }

    getAvailableLanguages() {
        return this.availablelangs;
    }

}
