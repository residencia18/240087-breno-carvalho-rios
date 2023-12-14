using System.Text;

namespace Semana1.MinimalAPI;

public static class Franklin {
    public static string Nome => "Franklin Menezes Pereira";

    
    public static List<(string,int)> Skills => new List<(string, int)>{
        ("Learn the Basics of C#", 2),
        ("General Development Skills", 3),
        ("Database Fundamentals", 2),
        ("ASP.NET Core Basics", 1),
        ("ORM", 1),
        ("Dependency Injection", 1),
        ("Coaching", 1),
        ("Databases", 2),
        ("Log Framaworks", 1),
        ("API Clients and Communications", 1),
        ("Real-Time Communication", 1),
        ("Object Mapping", 1),
        ("Task Scheduling", 1),
        ("Testing", 1),
        ("Micro-Services", 1),
        ("CI / CD", 1),
        ("Client Side Libraries", 1),
        ("Template Engines", 1),
        ("Good to Know Libraries", 1)  
    };

    public static string View() {
        var sb = new StringBuilder();
        sb.AppendLine($"Nome: {Nome}");
        sb.AppendLine();
        sb.AppendLine("Habilidades");
        foreach(var skill in Skills) {
            sb.AppendLine($"\t{skill.Item1} - {skill.Item2} estrelas");
        }

        var sum = Skills.Sum(x => x.Item2);
        sb.AppendLine();
        sb.AppendLine($"Total de estrelas: {sum}");

        return sb.ToString();
    }

}