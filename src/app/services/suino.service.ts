import { Injectable } from '@angular/core';
import { SuinoInputModel } from '../models/Suino/SuinoInputModel';
import { SuinoViewModel } from '../models/Suino/SuinoViewModel';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, map, of } from 'rxjs';
import { env } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class SuinoService {
  private readonly baseUrl = env.api.baseUrl;
  constructor(private http: HttpClient) { }

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

  calculateAge(dataNascimento: Date): number {
    const nascimento = new Date(dataNascimento);
    const hoje = new Date();

    const difAnos = hoje.getFullYear() - nascimento.getFullYear();
    const difMeses = (hoje.getMonth() + 1) - (nascimento.getMonth() + 1);
    const difDias = nascimento.getDay() - hoje.getDay();
    var idade = difAnos * 12 + difMeses;

    return difDias < 0 ? idade - 1 : idade;
  }
}
