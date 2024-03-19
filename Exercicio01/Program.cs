var lista = new List<double> { 3, 7, 2, 4, 6 };

var novaLista = lista.ConvertAll(item => item / 2);

novaLista.ForEach(item => Console.WriteLine(item));

