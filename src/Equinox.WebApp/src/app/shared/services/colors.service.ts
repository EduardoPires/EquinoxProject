import { Injectable } from "@angular/core";

@Injectable()
export class ColorsService {

    APP_COLORS = {
        "primary": "#5d9cec",
        "success": "#27c24c",
        "info": "#23b7e5",
        "warning": "#ff902b",
        "danger": "#f05050",
        "inverse": "#131e26",
        "green": "#37bc9b",
        "pink": "#f532e5",
        "purple": "#7266ba",
        "dark": "#3a3f51",
        "yellow": "#fad732",
        "gray-darker": "#232735",
        "gray-dark": "#3a3f51",
        "gray": "#dde6e9",
        "gray-light": "#e4eaec",
        "gray-lighter": "#edf1f2"
    };

    constructor() { }

    byName(name) {
        // console.log(name +' -> ' + this.APP_COLORS[name])
        return (this.APP_COLORS[name] || "#fff");
    }

}
