import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
    selector: '[appUnderlined]'
})
export class UnderlinedDirective {

    constructor(private element: ElementRef, private render: Renderer2) { }

    ngOnInit() {
        this.render.setStyle(this.element.nativeElement, 'text-decoration', 'underline');
    }

}
