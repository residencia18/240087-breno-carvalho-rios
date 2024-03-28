import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { env } from '../environment/environment';
import { AtividadeInputModel } from '../models/Atividade/AtividadeInputModel';
import { AtividadeViewModel } from '../models/Atividade/AtividadeViewModel';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AtividadeService {
  private readonly baseUrl = env.api.baseUrl;
  constructor(private http: HttpClient) { }

  public create(atividade: AtividadeInputModel) {
    return this.http.post<AtividadeInputModel>(`${this.baseUrl}/atividades.json`, atividade);
  }

  public update(id: string, atendimento: AtividadeInputModel) {
    return this.http.put(`${this.baseUrl}/atividades/${id}.json`, atendimento);
  }

  public delete(id: string) {
    return this.http.delete(`${this.baseUrl}/atividades/${id}.json`);
  }

  public getById(id: string) {
    return this.http.get<AtividadeViewModel>(`${this.baseUrl}/atividades/${id}.json`);
  }

  public getAll() {
    return this.http.get<AtividadeViewModel[]>(`${this.baseUrl}/atividades.json`).pipe(
      map((atividades) => {
        return Object.entries(atividades).map(([key, value]) => ({ ...value, id: key }) as AtividadeViewModel)
      })
    );
  }
}
