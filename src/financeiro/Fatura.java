package financeiro;

import cliente.Imovel;

import java.time.LocalDateTime;

public class Fatura {
    LocalDateTime data, ultimaLeitura, penultimaLeitura;
    double valor;
    boolean quitado;

    Imovel imovel;
}
