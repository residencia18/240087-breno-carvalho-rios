import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { env } from '../environment/environment';
import { map } from 'rxjs';
import { EventoViewModel } from '../models/Evento/EventoViewModel';
import { EventoInputModel } from '../models/Evento/EventoInputModel';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  private readonly baseUrl = env.api.baseUrl;
  constructor(private http: HttpClient) { }

  public create(evento: EventoInputModel) {
    return this.http.post<EventoInputModel>(`${this.baseUrl}/eventos.json`, evento);
  }

  public update(id: string, evento: EventoInputModel) {
    return this.http.put(`${this.baseUrl}/eventos/${id}.json`, evento);
  }

  public delete(id: string) {
    return this.http.delete(`${this.baseUrl}/eventos/${id}.json`);
  }

  public getById(id: string) {
    return this.http.get<EventoViewModel>(`${this.baseUrl}/eventos/${id}.json`);
  }

  public getAll() {
    return this.http.get<EventoViewModel[]>(`${this.baseUrl}/eventos.json`).pipe(
      map((eventos) => {
        return Object.entries(eventos).map(([key, value]) => ({ ...value, id: key }) as EventoViewModel)
      })
    );
  }
}
