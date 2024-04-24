using System.Text;
using RabbitMQ.Client;

namespace Namespace;
public class RabbitMQProducer
{
    public void Send(string message){
        var factory = new ConnectionFactory()
        {
            HostName = "srv508250.hstgr.cloud",
            UserName = "aluno",
            Password = "changeme"
        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel()){
            channel.QueueDeclare(
                queue: "Fila.Teste.Breno",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: "Fila.Teste.Breno",
                basicProperties: null,
                body: body
            );
        }
    }
}
