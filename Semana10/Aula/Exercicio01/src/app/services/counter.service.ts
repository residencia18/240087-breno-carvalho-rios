import { Injectable } from '@angular/core';
import { Observable, Subject, from } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CounterService {
  constructor() { }

  getNumbers(): Observable<number> {
    const interval = 100;
    const numberLimit = 100;
    return new Observable((subscriber) => {
      setInterval(() => {
        subscriber.complete();
      }, interval * (numberLimit + 1));
      
      for (let number = 1; number <= numberLimit; number++) {
        setInterval(() => {
          subscriber.next(number);
        }, interval * number);
      }
    });
  }
}
