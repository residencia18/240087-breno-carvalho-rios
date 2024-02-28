import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

type FormLogEvent = {
  "event": string,
  "element": string,
  "description": string,
  "dateTime": Date
}

@Injectable({
  providedIn: 'root'
})

export class FormLogService {
  private _formLog: FormLogEvent[] = [];
  private formLogSubject = new Subject<FormLogEvent>();
  public formLog$ = this.formLogSubject.asObservable();

  constructor() { }

  public registerEvent(event: FormLogEvent) {
    this._formLog.push(event);
    this.formLogSubject.next(event);
  }

  public getEvents() {
    return this._formLog;
  }
}
