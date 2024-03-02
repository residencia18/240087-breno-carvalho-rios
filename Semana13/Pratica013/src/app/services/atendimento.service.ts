import { Injectable } from '@angular/core';
import { AtendimentoInputModel } from '../models/Atendimento/AtendimentoInputModel';
import { AtendimentoViewModel } from '../models/Atendimento/AtendimentoViewModel';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AtendimentoService {
  private readonly baseUrl = "https://pratica013-frontend-default-rtdb.firebaseio.com/"
  constructor(private http: HttpClient) { }

  public create(atendimento: AtendimentoInputModel) {
    return this.http.post(`${this.baseUrl}/atendimentos.json`, atendimento);
  }

  public update(id: string, atendimento: AtendimentoInputModel) {
    return this.http.put(`${this.baseUrl}/atendimentos/${id}.json`, atendimento);
  }

  public delete(id: string) {
    return this.http.delete(`${this.baseUrl}/atendimentos/${id}.json`);
  }

  public getById(id: string) {
    return this.http.get<AtendimentoViewModel>(`${this.baseUrl}/atendimentos/${id}.json`);
  }

  public getAll() {
    return this.http.get<AtendimentoViewModel>(`${this.baseUrl}/atendimentos.json`).pipe(
      map((atendimentos) => {
        return Object.entries(atendimentos).map(([key, value]) => ({ ...value, id: key }) as AtendimentoViewModel)
      })
    );
  }
}
