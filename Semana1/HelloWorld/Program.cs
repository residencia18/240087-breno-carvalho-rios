#region Hello World
    Console.WriteLine("Hello World!");
#endregion

#region Teste de Tipos de Dados
    int tipoInteiro;
    long tipoLong;
    ulong tipoULong;
    double tipoDouble;
    string tipoString;

    tipoInteiro = int.MaxValue;
    tipoLong = long.MaxValue;
    tipoULong = ulong.MaxValue;

    Console.WriteLine("O máximo inteiro é: " + tipoInteiro);
    Console.WriteLine("O máximo long é: " + tipoLong);
    Console.WriteLine("O máximo ulong é: " + tipoULong);

    tipoLong = tipoInteiro;

    tipoString = "100";
    tipoInteiro = int.Parse(tipoString);

    Console.WriteLine(tipoInteiro);
#endregion
