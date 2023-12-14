using System.Text;

namespace Semana1.MinimalAPI;
public static class Daniel{
      public static string Name => "Daniel Coutinho Neto";
      public static List<(string, List<(string, int)>)> Skills => new List<(string, List<(string, int)>)>{
            ("Conhecimentos Básicos de C#", new List<(string, int)>{
                (" C#", 4),
                (".NET", 4),
                (".NET CLI", 4),
            }),
            ("Habilidades de Desenvolvimento Gerais", new List<(string, int)>{    
                ("Controle de Versão com o Git", 4),
                ("GitHub", 4),
                ("Protocolos HTTP / HTTPS", 3),
            }),
            ("Fundamentos de Banco de Dados", new List<(string, int)>{
                ("SQL - Básico", 4)
            }),
            ("ASPNET Core", new List<(string, int)>{    
                ("Básico ASPNET Core", 3),
                ("MVC", 3),
                ("APIs", 3),
            }),
         };
      public static string View(){
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine();
            sb.AppendLine("Habilidades:");
            sb.AppendLine();
            foreach(var topic in Skills){
                sb.AppendLine($"\t{topic.Item1} - Total: {topic.Item2.Sum(x => x.Item2)} estrelas");
                sb.AppendLine();
                foreach (var skill in topic.Item2) {
                  sb.AppendLine($"\t\t{skill.Item1} - {skill.Item2} estrelas");
                }
                sb.AppendLine();
            }
            var sum = getSum();
            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {sum}");
            return sb.ToString();
      }

      public static int getSum(){
        return Skills.Sum(x => x.Item2.Sum(x => x.Item2));
      }
}
