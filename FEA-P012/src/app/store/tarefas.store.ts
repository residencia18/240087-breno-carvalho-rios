import { patchState, signalStore, withMethods, withState } from "@ngrx/signals";
import { Tarefa } from "../tarefa.model";

export const tarefaStore = signalStore(
    { providedIn: 'root' },
    withState(
        {
            tarefas: [
                { id: '1', descricao: 'Aprender Angular com a residencia TIC18 do CEPEDI' },
                { id: '2', descricao: 'Aprender NgRx com a residencia TIC18 do CEPEDI' },
                { id: '3', descricao: 'Aprender Redux com a residencia TIC18 do CEPEDI' },
            ]
        }
    ),
    withMethods(
        (store) => ({
            adicionarTarefa(tarefa: Tarefa) {
                patchState(store, (estado) => (
                    { ...estado, tarefas: [...estado.tarefas, tarefa] }
                ));
            },
            removerTarefa(id: string) {
                console.log("Removeu")
                patchState(store, (estado) => (
                    { ...estado, tarefas: estado.tarefas.filter(tarefa => tarefa.id !== id) }
                ));
            }
        })
    )
);
