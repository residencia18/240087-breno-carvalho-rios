using System.Text;

namespace Semana1.MinimalAPI;
public static class Breno{
      public static string Name => "Breno Carvalho Rios";
      public static List<(string, List<(string, int)>)> Skills => new List<(string, List<(string, int)>)>{
            ("Básicos de C#", new List<(string, int)>{
                ("C#", 4),
                (".NET", 4),
                (".NET CLI", 4),
            }),
            ("Habilidades de Desenvolvimento Gerais", new List<(string, int)>{    
                ("Controle de Versão com o Git", 4),
                ("GitHub", 4),
                ("GitLab", 1),
                ("Protocolos HTTP / HTTPS", 5),
            }),
            ("Fundamentos de Banco de Dados", new List<(string, int)>{
                ("Design de Banco de Dados - Básico", 5),
                ("SQL - Básico", 5),
                ("Stored Procedures", 4),
                ("Constraints", 4),
                ("Triggers", 4),
            }),
            ("ASPNET Core", new List<(string, int)>{    
                ("Básico ASPNET Core", 4),
                ("MVC", 3),
                ("REST", 3),
            }),
            ("ORM", new List<(string, int)>{        
                ("Entity Framework Core", 1)
            }),
            ("Bancos de Dados Relacionais", new List<(string, int)>{        
                ("PostgreeSQL", 4),
                ("MariaDB", 4),
                ("MySQL", 4),
                ("SQL Server", 1)
            }),
            ("Bancos de Dados NoSQL", new List<(string, int)>{        
                ("MongoDB", 2),
                ("Cassandra", 1)
            }),
            ("Comunicação API e Clientes", new List<(string, int)>{        
                ("REST", 5),
                ("GraphQL", 1)
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
