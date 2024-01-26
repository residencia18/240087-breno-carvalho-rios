import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'wikipediaSpanToStrong'
})
export class WikipediaSpanToStrongPipe implements PipeTransform {

  transform(value: any): string {
    let newValue = value.replaceAll('<span class="searchmatch">', "<strong>").replaceAll("</span>", "</strong>");
    return newValue;
  }

}
