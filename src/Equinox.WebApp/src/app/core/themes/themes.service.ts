import { Injectable } from "@angular/core";

const themeA = require("../../shared/styles/themes/theme-a.scss");
const themeB = require("../../shared/styles/themes/theme-b.scss");
const themeC = require("../../shared/styles/themes/theme-c.scss");
const themeD = require("../../shared/styles/themes/theme-d.scss");
const themeE = require("../../shared/styles/themes/theme-e.scss");
const themeF = require("../../shared/styles/themes/theme-f.scss");
const themeG = require("../../shared/styles/themes/theme-g.scss");
const themeH = require("../../shared/styles/themes/theme-h.scss");

@Injectable()
export class ThemesService {

    styleTag: any;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
    defaultTheme: string = "H";

    constructor() {
        this.createStyle();

        if (localStorage.getItem("Theme") != null)
            this.defaultTheme = localStorage.getItem("Theme");

<<<<<<< HEAD
=======
    defaultTheme: string = "A";

    constructor() {
        this.createStyle();
>>>>>>> fd1205c... Bug fix while creating new Db.
<<<<<<< HEAD
=======
=======
    defaultTheme: string = "H";

    constructor() {
        this.createStyle();

        if (localStorage.getItem("Theme") != null)
            this.defaultTheme = localStorage.getItem("Theme");

>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
>>>>>>> c3e8855... Fixing rebase errors
        this.setTheme(this.defaultTheme);
    }

    private createStyle() {
        const head = document.head || document.getElementsByTagName("head")[0];
        this.styleTag = document.createElement("style");
        this.styleTag.type = "text/css";
        this.styleTag.id = "appthemes";
        head.appendChild(this.styleTag);
    }

    setTheme(name) {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        localStorage.setItem("Theme", name);
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
<<<<<<< HEAD
        localStorage.setItem("Theme", name);
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
        localStorage.setItem("Theme", name);
>>>>>>> 383c77b... * Recover Password
>>>>>>> f054a70... * Recover Password
=======
        localStorage.setItem("Theme", name);
>>>>>>> c3e8855... Fixing rebase errors
        switch (name) {
            case "A":
                this.injectStylesheet(themeA);
                break;
            case "B":
                this.injectStylesheet(themeB);
                break;
            case "C":
                this.injectStylesheet(themeC);
                break;
            case "D":
                this.injectStylesheet(themeD);
                break;
            case "E":
                this.injectStylesheet(themeE);
                break;
            case "F":
                this.injectStylesheet(themeF);
                break;
            case "G":
                this.injectStylesheet(themeG);
                break;
            case "H":
                this.injectStylesheet(themeH);
                break;
        }
    }

    injectStylesheet(css) {
        this.styleTag.innerHTML = css;
    }

    getDefaultTheme() {
        return this.defaultTheme;
    }

}
