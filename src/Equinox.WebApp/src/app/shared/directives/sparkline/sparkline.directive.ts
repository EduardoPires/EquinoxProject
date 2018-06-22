import { OnInit, OnDestroy, Directive, Input, ElementRef } from '@angular/core';
declare var $: any;

@Directive({
    selector: '[sparkline]'
})
export class SparklineDirective implements OnInit, OnDestroy {

    @Input() sparkline;
    @Input() values;

    // generate a unique resize event so we can detach later
    private resizeEventId = 'resize.sparkline' + 1324;
    private $element;

    constructor(private el: ElementRef) {
        this.$element = $(el.nativeElement);
    }

    ngOnInit() {
        this.initSparkLine();
    }

    initSparkLine() {
        let options = this.sparkline,
            data = this.$element.data();

        if (!options) {// if no scope options, try with data attributes
            options = data;
        }
        else {
            if (data) {// data attributes overrides scope options
                options = $.extend({}, options, data);
            }
        }

        options.type = options.type || 'bar'; // default chart is bar
        options.disableHiddenCheck = true;

        this.runSparkline(options);

        if (options.resize) {
            $(window).on(this.resizeEventId, () => {
                this.runSparkline(options);
            });
        }
    }

    runSparkline(options) {
        if(this.values) {
            if( typeof this.values === 'string')
                this.values = this.values.split(','); // assume comma separated string
            this.$element.sparkline(this.values, options);
        }
        else {
            this.$element.sparkline('html', options);
        }
    }

    ngOnDestroy() {
        $(window).off(this.resizeEventId);
    }
}
