import { Directive, ElementRef } from '@angular/core';
declare var $: any;

@Directive({
    selector: '[checkAll]'
})
export class CheckallDirective {

    constructor(public el: ElementRef) {
        let $element = $(el.nativeElement);

        $element.on('change', function() {
            let index = $element.index() + 1,
                checkbox = $element.find('input[type="checkbox"]'),
                table = $element.parents('table');
            // Make sure to affect only the correct checkbox column
            table.find('tbody > tr > td:nth-child(' + index + ') input[type="checkbox"]')
                .prop('checked', checkbox[0].checked);

        });

    }

}
