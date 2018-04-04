import { NgModule } from "@angular/core";

import { LayoutComponent } from "./layout.component";
import { SidebarComponent } from "./sidebar/sidebar.component";
import { HeaderComponent } from "./header/header.component";
import { NavsearchComponent } from "./header/navsearch/navsearch.component";
import { OffsidebarComponent } from "./offsidebar/offsidebar.component";
import { UserblockComponent } from "./sidebar/userblock/userblock.component";
import { UserblockService } from "./sidebar/userblock/userblock.service";
import { FooterComponent } from "./footer/footer.component";

import { SharedModule } from "../shared.module";
<<<<<<< HEAD
<<<<<<< HEAD
import { AccountManagementService } from "../services/account-management.service";
=======
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
import { AccountManagementService } from "../services/account-management.service";
>>>>>>> 86e6256... Daily commit

@NgModule({
    imports: [
        SharedModule
    ],
    providers: [
<<<<<<< HEAD
<<<<<<< HEAD
        UserblockService,
        AccountManagementService
=======
        UserblockService
>>>>>>> fd1205c... Bug fix while creating new Db.
=======
        UserblockService,
        AccountManagementService
>>>>>>> 86e6256... Daily commit
    ],
    declarations: [
        LayoutComponent,
        SidebarComponent,
        UserblockComponent,
        HeaderComponent,
        NavsearchComponent,
        OffsidebarComponent,
        FooterComponent
    ],
    exports: [
        LayoutComponent,
        SidebarComponent,
        UserblockComponent,
        HeaderComponent,
        NavsearchComponent,
        OffsidebarComponent,
        FooterComponent
    ]
})
export class LayoutModule { }
