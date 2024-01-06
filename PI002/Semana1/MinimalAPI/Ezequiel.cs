using System.Text;

namespace Semana1.MinimalAPI;
public static class Ezequiel{
      public static string Name => "Ezequiel Lobo Oliveira";
      public static List<(string, List<(string, int)>)> Skills => new List<(string, List<(string, int)>)>{
            ("Básicos de C#", new List<(string, int)>{
                ("C#", 3),
                (".NET", 3),
                (".NET CLI", 2),
            }),
            ("Habilidades de Desenvolvimento Gerais", new List<(string, int)>{    
                ("Controle de Versão com o Git", 3),
                ("GitHub", 4),
                ("GitLab", 1),
                ("Protocolos HTTP / HTTPS", 2),
            }),
            ("Fundamentos de Banco de Dados", new List<(string, int)>{
                ("Design de Banco de Dados - Básico", 4),
                ("SQL - Básico", 4),
                ("Stored Procedures", 2),
                ("Constraints", 2),
                ("Triggers", 1),
            }),
            ("Bancos de Dados Relacionais", new List<(string, int)>{        
                ("MySQL", 4),
                ("SQL Server", 1)
            }),
            ("ASPNET Core", new List<(string, int)>{    
                ("Básico ASPNET Core", 3),
                ("MVC", 3),
                ("REST", 3),
            }),
           
         };
      public static string View(){
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {getSum()}");
            sb.AppendLine();
            sb.AppendLine("Habilidades:");
            sb.AppendLine();
            foreach(var topic in Skills){
                int topicTotal = topic.Item2.Sum(x => x.Item2);
                sb.AppendLine($"\t{topic.Item1} - Total: {topicTotal} {(topicTotal > 1 ? "estrelas" : "estrela")}");
                sb.AppendLine();
                foreach (var skill in topic.Item2) {
                    sb.AppendLine($"\t\t{skill.Item1} - {skill.Item2} {(skill.Item2 > 1 ? "estrelas" : "estrela")}");
                }
                sb.AppendLine();
            }
            
            return sb.ToString();
      }

      public static int getSum(){
        return Skills.Sum(x => x.Item2.Sum(x => x.Item2));
      }
}
