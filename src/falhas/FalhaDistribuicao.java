package falhas;

import cliente.Imovel;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;

public class FalhaDistribuicao extends Falha{
    private ArrayList<Reparo> reparos = new ArrayList<>();

    public FalhaDistribuicao(String descricao, LocalDate previsao, Imovel imovel) {
        super(descricao, previsao, imovel);
    }

    public ArrayList<Reparo> getReparos() {
        return reparos;
    }
}
