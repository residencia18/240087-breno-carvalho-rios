import { Injectable } from '@angular/core';
import { SuinoInputModel } from '../models/Suino/SuinoInputModel';
import { SuinoViewModel } from '../models/Suino/SuinoViewModel';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SuinoService {
  private readonly baseUrl = "https://pratica015-frontend-default-rtdb.firebaseio.com/"
  constructor(private http: HttpClient) { }

  public create(atendimento: SuinoInputModel) {
    return this.http.post(`${this.baseUrl}/suinos.json`, atendimento);
  }

  public update(id: string, atendimento: SuinoInputModel) {
    return this.http.put(`${this.baseUrl}/suinos/${id}.json`, atendimento);
  }

  public delete(id: string) {
    this.http.delete(`${this.baseUrl}/pesos/${id}.json`);
    return this.http.delete(`${this.baseUrl}/suinos/${id}.json`);
  }

  public getById(id: string) {
    return this.http.get<SuinoViewModel>(`${this.baseUrl}/suinos/${id}.json`);
  }

  public getAll() {
    return this.http.get<SuinoViewModel>(`${this.baseUrl}/suinos.json`).pipe(
      map((suinos) => {
        return Object.entries(suinos).map(([key, value]) => ({ ...value, id: key }) as SuinoViewModel)
      })
    );
  }
}
