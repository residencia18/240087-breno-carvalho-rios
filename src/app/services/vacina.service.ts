import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { env } from '../environment/environment';
import { VacinaInputModel } from '../models/Vacina/VacinaInputModel';
import { VacinaViewModel } from '../models/Vacina/VacinaViewModel';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VacinaService {
  private readonly baseUrl = env.api.baseUrl;
  constructor(private http: HttpClient) { }

  public create(vacina: VacinaInputModel) {
    return this.http.post<VacinaInputModel>(`${this.baseUrl}/vacinas.json`, vacina);
  }

  public update(id: string, atendimento: VacinaInputModel) {
    return this.http.put(`${this.baseUrl}/vacinas/${id}.json`, atendimento);
  }

  public delete(id: string) {
    return this.http.delete(`${this.baseUrl}/vacinas/${id}.json`);
  }

  public getById(id: string) {
    return this.http.get<VacinaViewModel>(`${this.baseUrl}/vacinas/${id}.json`);
  }

  public getAll() {
    return this.http.get<VacinaViewModel[]>(`${this.baseUrl}/vacinas.json`).pipe(
      map((vacinas) => {
        return Object.entries(vacinas).map(([key, value]) => ({ ...value, id: key }) as VacinaViewModel)
      })
    );
  }
}
