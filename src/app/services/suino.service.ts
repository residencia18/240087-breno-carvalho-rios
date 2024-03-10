import { Injectable } from '@angular/core';
import { SuinoInputModel } from '../models/Suino/SuinoInputModel';
import { SuinoViewModel } from '../models/Suino/SuinoViewModel';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SuinoService {
  private readonly baseUrl = "https://pratica15-suino-default-rtdb.firebaseio.com/"
  constructor(private http: HttpClient) { }

  // public create(atendimento: SuinoInputModel) {
  //   return this.http.post(`${this.baseUrl}/suinos.json`, atendimento);
  // }

  public create(suino: SuinoInputModel) {
    return this.http.post<SuinoInputModel>(`${this.baseUrl}/suinos.json`, suino);
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

  // public getAll() {
  //   return this.http.get<SuinoViewModel>(`${this.baseUrl}/suinos.json`).pipe(
  //     map((suinos) => {
  //       return Object.entries(suinos).map(([key, value]) => ({ ...value, id: key }) as SuinoViewModel)
  //     })
  //   );
  // }

  public getAll() {
    return this.http.get<{ [key: string]: SuinoViewModel }>(`${this.baseUrl}/suinos.json`).pipe(
      map((suinos) => {
        return Object.keys(suinos).map((key) => ({ ...suinos[key], id: key }));
      })
    );
  }

  // Método para verificar se já existe um suíno com o brinco fornecido
  getByBrinco(brinco: number): Observable<SuinoViewModel | null> {
    return this.getAll().pipe(
      map(suinos => suinos.find(suino => `${suino.brinco}` === `${brinco}`) || null),
      catchError(error => {
        console.error('Erro ao buscar suíno:', error);
        return of(null); // Retorna null em caso de erro
      })
    );
  }
}