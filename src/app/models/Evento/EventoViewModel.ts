import { SuinoViewModel } from "../Suino/SuinoViewModel";
import { VacinaViewModel } from "../Vacina/VacinaViewModel";

export interface EventoViewModel {
    id: string,
    nome: string,
    data: Date,
    vacinas: VacinaViewModel[],
    suinos: SuinoViewModel[]
}