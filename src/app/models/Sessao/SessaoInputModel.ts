import { SuinoInputModel } from "../Suino/SuinoInputModel";
import { VacinaInputModel } from "../Vacina/VacinaInputModel";

export interface SessaoInputModel {
    nome: string,
    data: Date,
    vacinas: VacinaInputModel[],
    suinos: SuinoInputModel[]
}