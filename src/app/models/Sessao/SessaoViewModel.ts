import { SuinoViewModel } from "../Suino/SuinoViewModel";
import { AtividadeViewModel } from "../Atividade/AtividadeViewModel";
import { Realizacao } from "./Realizacao";

export interface SessaoViewModel {
    id: string,
    nome: string,
    data: Date,
    atividades: AtividadeViewModel[],
    suinos: SuinoViewModel[],
    realizacoes: Realizacao[]
}
