try
{
    object o = null;
    o.ToString();
}
catch (NullReferenceException)
{
    Console.WriteLine("Não é possível converter um objeto nulo em string");
}
