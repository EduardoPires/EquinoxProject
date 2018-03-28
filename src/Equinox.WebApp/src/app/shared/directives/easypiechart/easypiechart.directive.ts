import { OnInit, OnChanges, Directive, Input, SimpleChange, ElementRef } from '@angular/core';

declare var $: any;
declare var EasyPieChart: any;

@Directive({
    selector: '[easypiechart]'
})
export class EasypiechartDirective implements OnInit, OnChanges {

    /**
     * default easy pie chart options
     * @type {Object}
     */
    public defaultOptions = {
        barColor: '#ef1e25',
        trackColor: '#f9f9f9',
        scaleColor: '#dfe0e0',
        scaleLength: 5,
        lineCap: 'round',
        lineWidth: 3,
        size: 110,
        rotate: 0,
        animate: {
            duration: 1000,
            enabled: true
        }
    };

    public pieChart: any;
    @Input() percent;
    @Input() options;

    constructor(public element: ElementRef) {
        this.percent = this.percent || 0;
        this.options = $.extend({}, this.defaultOptions, this.options);
    }

    ngOnInit() {
        if(EasyPieChart) {
            this.pieChart = new EasyPieChart(this.element.nativeElement, this.options);
            this.pieChart.update(this.percent);
        }
    }

    ngOnChanges(changes: { [propertyName: string]: SimpleChange }) {
        if (this.pieChart && changes['percent']) {
            this.pieChart.update(this.percent);
        }
    }

}
