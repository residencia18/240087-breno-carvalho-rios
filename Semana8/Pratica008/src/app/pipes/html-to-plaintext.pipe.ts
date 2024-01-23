import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'htmlToPlainText'
})
export class HtmlToPlaintextPipe implements PipeTransform {
  transform(value: any): string {
    let newValue = value.replaceAll('<span class="searchmatch">', "<strong>").replaceAll("</span>", "</strong>");
    return newValue;
  }
}
