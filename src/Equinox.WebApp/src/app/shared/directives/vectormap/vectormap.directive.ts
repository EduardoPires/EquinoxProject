import { OnInit, Directive, Input, ElementRef, OnDestroy } from '@angular/core';
declare var $: any;

@Directive({
    selector: '[vectormap]'
})
export class VectormapDirective implements OnInit, OnDestroy {

    @Input() mapHeight: number;
    @Input() mapName: any;
    @Input() mapOptions: any;
    @Input() seriesData: any;
    @Input() markersData: any;

    $element: any;

    constructor(public element: ElementRef) { }

    ngOnInit() {

        this.$element = $(this.element.nativeElement);
        this.$element.css('height', this.mapHeight);

        if (!this.$element.length || !this.$element.vectorMap) {
            return;
        }

        this.$element.vectorMap({
            map: this.mapName,
            backgroundColor: this.mapOptions.bgColor,
            zoomMin: 1,
            zoomMax: 8,
            zoomOnScroll: false,
            regionStyle: {
                initial: {
                    'fill': this.mapOptions.regionFill,
                    'fill-opacity': 1,
                    'stroke': 'none',
                    'stroke-width': 1.5,
                    'stroke-opacity': 1
                },
                hover: {
                    'fill-opacity': 0.8
                },
                selected: {
                    fill: 'blue'
                },
                selectedHover: {
                }
            },
            focusOn: { x: 0.4, y: 0.6, scale: this.mapOptions.scale },
            markerStyle: {
                initial: {
                    fill: this.mapOptions.markerColor,
                    stroke: this.mapOptions.markerColor
                }
            },
            onRegionLabelShow: (e, el, code) => {
                if (this.seriesData && this.seriesData[code]) {
                    el.html(el.html() + ': ' + this.seriesData[code] + ' visitors');
                }
            },
            markers: this.markersData,
            series: {
                regions: [{
                    values: this.seriesData,
                    scale: this.mapOptions.scaleColors,
                    normalizeFunction: 'polynomial'
                }]
            },
        });
    }

    ngOnDestroy() {
        this.$element.vectorMap('get', 'mapObject').remove();
    }

}
