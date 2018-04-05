import { browser, by, element } from "protractor";

export class EquinoxWebAppPage {
    navigateTo() {
        return browser.get("/");
    }

    getUrl() {
        return browser.getCurrentUrl();
    }

    getParagraphText() {
        return element(by.css("login-container text-center py-2")).getText();
    }
}
