import { SuinoInputModel } from "../Suino/SuinoInputModel";
import { AtividadeInputModel } from "../Atividade/AtividadeInputModel";
import { Realizacao } from "./Realizacao";

export interface SessaoInputModel {
    nome: string,
    data: Date,
    atividades: AtividadeInputModel[],
    suinos: SuinoInputModel[],
    realizacoes: Realizacao
}
