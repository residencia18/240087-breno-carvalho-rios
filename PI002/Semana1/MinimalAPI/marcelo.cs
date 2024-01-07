using System.Text;

namespace Semana1.MinimalAPI;
public static class Marcelo{
      public static string Name => "Marcelo da Silva Cruz";
      public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 4),
            ("Habilidades Gerais de Desenvolvimento",3),
            ("Fundamentos de Banco de Dados",3),
            ("Fundamentos de PHP", 2),
            ("ASP.NET Core Basics", 1),
            ("Redes de Computadores", 5),
            ("Controle de Versão com o Git", 4),            
            ("GitHub", 5),
            ("GitLab", 1),
            ("Protocolos HTTP / HTTPS", 5),
            ("Design de Banco de Dados - Básico", 5),
            ("SQL - Básico", 5),
            ("PostgreeSQL", 1),
            ("MariaDB", 4),
            ("MySQL", 4),
            ("SQL Server", 1),
            ("ORM", 1),
            ("MVC", 1),
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
