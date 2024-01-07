using System.Text;

namespace Semana1.MinimalAPI;
public static class HomePage
{
    public static string Name => "Breno Carvalho Rios";
    public static string View()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Nome: {Breno.Name}");
        sb.AppendLine($"Total de estrelas: {Breno.getSum()}");
        sb.AppendLine();
        sb.AppendLine($"Ezequiel: {Ezequiel.Name}");
        sb.AppendLine($"Total de estrelas: {Ezequiel.getSum()}");
        sb.AppendLine();
        sb.AppendLine($"Nome: {Franklin.Nome}");
        sb.AppendLine($"Total de estrelas: {Franklin.Skills.Sum(x => x.Item2)}");
        sb.AppendLine();
        sb.AppendLine($"Ezequiel: {AlanCarlos.Name}");
        sb.AppendLine($"Total de estrelas: {AlanCarlos.Skills.Sum(x => x.Item2)}");
        sb.AppendLine();
        sb.AppendLine($"Total de estrelas da equipe: {Breno.getSum() + Ezequiel.getSum() + Franklin.Skills.Sum(x => x.Item2) + AlanCarlos.Skills.Sum(x => x.Item2)}");

        return sb.ToString();
    }
}
