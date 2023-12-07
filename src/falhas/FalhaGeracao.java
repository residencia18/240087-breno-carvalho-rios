package falhas;

import cliente.Imovel;

import java.time.LocalDate;
import java.time.LocalDateTime;

public class FalhaGeracao extends Falha{
    public FalhaGeracao(String descricao, LocalDate previsao, Imovel imovel) {
        super(descricao, previsao, imovel);
    }
}
