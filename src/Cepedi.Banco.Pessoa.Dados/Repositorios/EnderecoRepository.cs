using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cepedi.Banco.Pessoa.Dados.Repositorios;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly ApplicationDbContext _context;

    public EnderecoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Update(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> CadastrarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Add(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> ExcluirEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Remove(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> ObterEnderecoAsync(int id)
    {
        var endereco = await _context.Endereco.FirstOrDefaultAsync(endereco => endereco.Id == id);
        return endereco;
    }

    public async Task<EnderecoEntity> ObterEnderecoPorCepAsync(string cep)
    {
        var endereco = await _context.Endereco.FirstOrDefaultAsync(endereco => endereco.Cep == cep);
        return endereco;
    }

    public async Task<List<EnderecoEntity>> ObterTodosEnderecosAsync()
    {
        var enderecos = await _context.Endereco.ToListAsync();
        return enderecos;
    }

    // public void RabbitProdutor(){
    //     var factory = new ConnectionFactory() { hostname: "localhost" };

    //     using (var connection = factory.CreateConnection())
    //     using (var channel = connection.CreateModel()){
    //         channel.QueueDeclare(
    //             queue: "Hello",
    //             durable: false,
    //             exclusive: false,
    //             autoDelete: false,
    //             arguments: null
    //         );
    //         string message = "Hello World";
    //         var body = Encoding.UTF8.GetBytes(message);

    //         channel.BasicPublish(
    //             exchange: "",
    //             routingKey: "Hello",
    //             basicProperties: null,
    //             body: body
    //         );

    //         Console.WriteLine($"[X] Sent {0}", message);
    //         Console.WriteLine($"Press [enter] to exit.");
    //         Console.ReadLine();
    //     }
    // }

    // public void RabbitConsumidor(){
    //     var factory = new ConnectionFactory() { hostname = "srv508250.hstgr.cloud" };
    //     using (var connection = factory.CreateConnection())
    //     using (var channel = connection.CreateModel()){
    //         channel.QueueDeclare(
    //             queue: "FilaRabbitMQ",
    //             durable: false,
    //             exclusive: false,
    //             autoDelete: false,
    //             arguments: null
    //         );
            
    //         var consumer = new EventingBasicConsumer(channel);

    //         consumer.Received += (model, ea) => {
    //             var body = ea.Body.ToArray();
    //             var message = Encoding.UTF8.GetString(body);
    //             Console.WriteLine("Received {0}", message);
    //         }

    //         channel.BasicConsume(
    //             queue: "FilaRabbitMQ",
    //             autoAck: true,
    //             consumer: consumer
    //         );

    //         Console.WriteLine($"Press [enter] to exit.");
    //         Console.ReadLine();
    //     }
    // }
}
