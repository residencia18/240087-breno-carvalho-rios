import { createReducer, on } from "@ngrx/store";
import { Tarefa } from "../tarefa.model";
import { adicionarTarefa, atualizarTarefa, removerTarefa } from "./tarefa.actions";

export interface TarefaState {
    tarefas: Tarefa[];
}

export const estadoInicial: TarefaState = {
    tarefas: [
        { id: '1', descricao: 'Aprender Angular com a residencia TIC18 do CEPEDI' },
        { id: '2', descricao: 'Aprender NgRx com a residencia TIC18 do CEPEDI' },
        { id: '3', descricao: 'Aprender Redux com a residencia TIC18 do CEPEDI' },
    ]
};

export const tarefasReducer = createReducer(
    estadoInicial,
    on(adicionarTarefa, (estado, action) => ({ ...estado, tarefas: [...estado.tarefas, action.tarefa] })),
    on(atualizarTarefa, (estado, action) => {
        estado.tarefas.map(t => t.id === action.task.id ? action.task : t);
        return { ...estado, tarefas: estado.tarefas.map(t => t.id === action.task.id ? action.task : t) };
    }),
    on(removerTarefa, (estado, action) => ({ ...estado, tarefas: estado.tarefas.filter(t => t.id !== action.id) })),
);




