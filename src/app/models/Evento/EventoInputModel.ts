import { SuinoInputModel } from "../Suino/SuinoInputModel";
import { VacinaInputModel } from "../Vacina/VacinaInputModel";

export interface EventoInputModel {
    nome: string,
    data: Date,
    vacinas: VacinaInputModel[],
    suinos: SuinoInputModel[]
}