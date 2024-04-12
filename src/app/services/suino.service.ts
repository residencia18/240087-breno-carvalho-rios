import { Injectable } from '@angular/core';
import { SuinoInputModel } from '../models/Suino/SuinoInputModel';
import { SuinoViewModel } from '../models/Suino/SuinoViewModel';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, map, of, tap } from 'rxjs';
import { env } from '../environment/environment';
import { AtividadeViewModel } from '../models/Atividade/AtividadeViewModel';

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

  getAtividadesByBrinco(brinco: number) {
    return this.http.get<{ [key: string]: AtividadeViewModel }>(`${this.baseUrl}/sessoes.json`).pipe(
      map((sessoes) => {
        return Object.keys(sessoes).map((key) => ({ ...sessoes[key], id: key }));
      }),
      map(sessoes => {
        return sessoes.filter(sessao => sessao.suinos.some(suino => suino.brinco == brinco));
      }),
      map(sessoes => {
        return sessoes.map((sessao: any) => sessao.realizacoes)
      }),
      map(realizacoes => {
        return realizacoes.map((_realizacoes: any) => {
          return _realizacoes.find((_realizacao: any) => {
            return _realizacao.suino == brinco
          });
        })
      }),
      map(realizacoes => {
        return realizacoes.map((_realizacao: any) => {
          return _realizacao.atividades.find((atividade: any) => atividade.realizada = true);
        });
      })
    );
  }

  calculateAge(dataNascimento: Date): number {
    const nascimento = new Date(dataNascimento);
    const hoje = new Date();

    const difAnos = hoje.getFullYear() - nascimento.getFullYear();
    const difMeses = (hoje.getMonth() + 1) - (nascimento.getMonth() + 1);
    const difDias = hoje.getDay() - nascimento.getDay();
    var idade = difAnos * 12 + difMeses;

    return (difDias < 0 && difMeses > 0) ? idade - 1 : idade;
  }
}
