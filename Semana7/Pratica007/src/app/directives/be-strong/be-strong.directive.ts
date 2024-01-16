import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
    selector: '[appBeStrong]'
})
export class BeStrongDirective {

    constructor(private element: ElementRef, private render: Renderer2) { }

    ngOnInit() {
        this.render.setStyle(this.element.nativeElement, 'font-weight', 'bold');
    }
}
