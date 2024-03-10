import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PesoInputModel } from '../models/Peso/PesoInputModel';
import { PesoViewModel } from '../models/Peso/PesoViewModel';
import { map } from 'rxjs';
import { env } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class PesoService {
  private readonly baseUrl = env.api.baseUrl;
  constructor(private http: HttpClient) { }

  public create(suinoId: string, peso: PesoInputModel) {
    return this.http.post(`${this.baseUrl}/pesos/${suinoId}.json`, peso);
  }

  public update(id: string, suinoId: string, peso: PesoInputModel) {
    return this.http.put(`${this.baseUrl}/pesos/${suinoId}/${id}.json`, peso);
  }

  public delete(id: string, suinoId: string) {
    return this.http.delete(`${this.baseUrl}/pesos/${suinoId}/${id}.json`);
  }

  public getById(id: string, suinoId: string) {
    return this.http.get<PesoViewModel>(`${this.baseUrl}/pesos/${suinoId}/${id}.json`);
  }

  public getAll(suinoId: string) {
    return this.http.get<PesoViewModel>(`${this.baseUrl}/pesos/${suinoId}.json`).pipe(
      map((pesos) => {
        if (!pesos) {
          return [];
        }
        return Object.entries(pesos).map(([key, value]) => ({ ...value, id: key }) as PesoViewModel)
      })
    )
  }
}
