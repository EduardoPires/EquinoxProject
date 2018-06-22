import { Directive, Input, OnInit, OnDestroy, ElementRef, OnChanges, SimpleChange } from '@angular/core';
declare var $: any;

@Directive({
    selector: '[jqcloud]'
})
export class JqcloudDirective implements OnInit, OnDestroy, OnChanges {

    @Input() words;
    @Input() width;
    @Input() height;
    @Input() steps;
    $elem: any;
    options: any;
    initialized = false; // flag to not update before plugin was initialized

    constructor(element: ElementRef) {
        this.$elem = $(element.nativeElement);
        this.options = $.fn.jQCloud.defaults.get();
    }

    ngOnInit() {
        let opts: any = {};
        if (this.width) {
            opts.width = this.width;
        }
        if (this.height) {
            opts.height = this.height;
        }
        if (this.steps) {
            opts.steps = this.steps;
        }

        $.extend(this.options, opts);
        this.$elem.jQCloud(this.words, opts);
        this.initialized = true;
    }

    ngOnChanges(changes: { [propertyName: string]: SimpleChange }) {
        if (this.initialized && this.words && changes['words']) {
            this.$elem.jQCloud('update', this.words);
        }
    }

    ngOnDestroy() {
        this.$elem.jQCloud('destroy');
    }
}
