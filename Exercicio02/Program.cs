using Exercicio02.Classes;

Data d1 = new Data(10, 03, 2000, 10, 30, 10);
d1.Imprimir(Data.FORMATO_12H);
d1.Imprimir(Data.FORMATO_24H);

Data d2 = new Data(15, 06, 2000, 23, 15, 20);
d2.Imprimir(Data.FORMATO_12H);
d2.Imprimir(Data.FORMATO_24H);

Data d3 = new Data(5, 10, 2005);
d3.Imprimir(Data.FORMATO_12H);
d3.Imprimir(Data.FORMATO_24H);
