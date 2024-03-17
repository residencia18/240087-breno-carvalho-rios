import { SuinoInputModel } from "../Suino/SuinoInputModel";
import { VacinaInputModel } from "../Vacina/VacinaInputModel";
import { Aplicacao } from "./Aplicacao";

export interface SessaoInputModel {
    nome: string,
    data: Date,
    vacinas: VacinaInputModel[],
    suinos: SuinoInputModel[],
    aplicacoes: Aplicacao
}
