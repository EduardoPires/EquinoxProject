import { NgModule, ModuleWithProviders } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { TranslateModule } from "@ngx-translate/core";
import { ToasterModule } from "angular2-toaster/angular2-toaster";

import { AccordionModule } from "ngx-bootstrap/accordion";
import { AlertModule } from "ngx-bootstrap/alert";
import { ButtonsModule } from "ngx-bootstrap/buttons";
import { CarouselModule } from "ngx-bootstrap/carousel";
import { CollapseModule } from "ngx-bootstrap/collapse";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { ModalModule } from "ngx-bootstrap/modal";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { ProgressbarModule } from "ngx-bootstrap/progressbar";
import { RatingModule } from "ngx-bootstrap/rating";
import { TabsModule } from "ngx-bootstrap/tabs";
import { TimepickerModule } from "ngx-bootstrap/timepicker";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { PopoverModule } from "ngx-bootstrap/popover";
import { TypeaheadModule } from "ngx-bootstrap/typeahead";
import { DatepickerModule } from "ngx-bootstrap/datepicker";

import { FlotDirective } from "./directives/flot/flot.directive";
import { SparklineDirective } from "./directives/sparkline/sparkline.directive";
import { EasypiechartDirective } from "./directives/easypiechart/easypiechart.directive";
import { CheckallDirective } from "./directives/checkall/checkall.directive";
import { VectormapDirective } from "./directives/vectormap/vectormap.directive";
import { NowDirective } from "./directives/now/now.directive";
import { ScrollableDirective } from "./directives/scrollable/scrollable.directive";
import { JqcloudDirective } from "./directives/jqcloud/jqcloud.directive";
import { ColorsService } from "./services/colors.service";
import {TextMaskModule} from "angular2-text-mask";

// https://angular.io/styleguide#!#04-10
@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        TranslateModule,
        AccordionModule.forRoot(),
        AlertModule.forRoot(),
        ButtonsModule.forRoot(),
        CarouselModule.forRoot(),
        CollapseModule.forRoot(),
        DatepickerModule.forRoot(),
        BsDropdownModule.forRoot(),
        ModalModule.forRoot(),
        PaginationModule.forRoot(),
        ProgressbarModule.forRoot(),
        RatingModule.forRoot(),
        TabsModule.forRoot(),
        TimepickerModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        TypeaheadModule.forRoot(),
        ToasterModule
    ],
    providers: [
        ColorsService
    ],
    declarations: [
        FlotDirective,
        SparklineDirective,
        EasypiechartDirective,
        CheckallDirective,
        VectormapDirective,
        NowDirective,
        ScrollableDirective,
        JqcloudDirective
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        TranslateModule,
        RouterModule,
        AccordionModule,
        AlertModule,
        ButtonsModule,
        CarouselModule,
        CollapseModule,
        DatepickerModule,
        BsDropdownModule,
        ModalModule,
        PaginationModule,
        ProgressbarModule,
        RatingModule,
        TabsModule,
        TimepickerModule,
        TooltipModule,
        PopoverModule,
        TypeaheadModule,
        ToasterModule,
        FlotDirective,
        SparklineDirective,
        EasypiechartDirective,
        CheckallDirective,
        VectormapDirective,
        NowDirective,
        ScrollableDirective,
        JqcloudDirective,
        TextMaskModule
    ]
})

// https://github.com/ocombe/ng2-translate/issues/209
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule
        };
    }
}
