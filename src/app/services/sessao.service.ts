import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { env } from '../environment/environment';
import { map } from 'rxjs';
import { SessaoViewModel } from '../models/Sessao/SessaoViewModel';
import { SessaoInputModel } from '../models/Sessao/SessaoInputModel';

@Injectable({
  providedIn: 'root'
})
export class SessaoService {
  private readonly baseUrl = env.api.baseUrl;
  constructor(private http: HttpClient) { }

  public create(sessao: SessaoInputModel) {
    return this.http.post<SessaoInputModel>(`${this.baseUrl}/sessoes.json`, sessao);
  }

  public update(id: string, sessao: SessaoInputModel) {
    return this.http.put(`${this.baseUrl}/sessoes/${id}.json`, sessao);
  }

  public delete(id: string) {
    return this.http.delete(`${this.baseUrl}/sessoes/${id}.json`);
  }

  public getById(id: string) {
    return this.http.get<SessaoViewModel>(`${this.baseUrl}/sessoes/${id}.json`);
  }

  public getAll() {
    return this.http.get<SessaoViewModel[]>(`${this.baseUrl}/sessoes.json`).pipe(
      map((sessoes) => {
        const _sessoes: SessaoViewModel[] = Object.entries(sessoes).map(([key, value]) => ({ ...value, id: key }) as SessaoViewModel);
        return _sessoes;
      })
    );
  }
}
