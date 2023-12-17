using System.Text;

namespace Semana1.MinimalAPI;
public static class AlanCarlos{
      public static string Name => "Alan Carlos";
      public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 3),
            ("Habilidades Gerais de Desenvolvimento",3),
            ("Fundamentos de Banco de Dados",3),
            ("Fundamentos de PHP", 4),
            ("Redes de Computadores", 5),
         };
      public static string View(){
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine();
            sb.AppendLine("Habilidades:");
            foreach(var skill in Skills){
                  sb.AppendLine($"\t{skill.Item1} - {skill.Item2} estrelas");
            }
            var sum = Skills.Sum(x => x.Item2);
            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {sum}");
            return sb.ToString();
      }
}