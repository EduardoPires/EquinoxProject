import { EquinoxWebAppPage } from "./app.po";
import { TestBed } from "@angular/core/testing";
import { AccountManagementService } from "../src/app/shared/services/account-management.service";
import { HttpClientModule } from "@angular/common/http";

describe("Equinox WebApp", function () {
  let page: EquinoxWebAppPage;

  beforeEach(() => {
    page = new EquinoxWebAppPage();
  });

  it("should display sign-in page", () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual("SIGN IN TO CONTINUE.");
    expect(page.getUrl()).toContain("/sign-in");
  });
});
