import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'initials',
  standalone: true
})
export class InitialsPipe implements PipeTransform {

  transform(value: string, ...args: any[]): string {
    if (!value) {
      return '';
    }

    let names = value.split(' ');
    let firstName = names[0].charAt(0).toUpperCase();
    let lastName = names[names.length - 1].charAt(0).toUpperCase();

    return `${firstName}${lastName}`;
  }

}
