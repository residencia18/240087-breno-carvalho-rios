import { SuinoViewModel } from "../Suino/SuinoViewModel";
import { VacinaViewModel } from "../Vacina/VacinaViewModel";
import { Aplicacao } from "./Aplicacao";

export interface SessaoViewModel {
    id: string,
    nome: string,
    data: Date,
    vacinas: VacinaViewModel[],
    suinos: SuinoViewModel[],
    aplicacoes: Aplicacao[]
}
