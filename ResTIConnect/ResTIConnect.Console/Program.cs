using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure;

var dbContext = new ResTIConnectContext();

dbContext.Perfis.RemoveRange(dbContext.Perfis);
dbContext.Usuarios.RemoveRange(dbContext.Usuarios);
dbContext.Enderecos.RemoveRange(dbContext.Enderecos);
dbContext.Sistemas.RemoveRange(dbContext.Sistemas);
dbContext.Eventos.RemoveRange(dbContext.Eventos);
dbContext.Logs.RemoveRange(dbContext.Logs);

var perfil = new Perfil
{
    Descricao = "Administrador",
    Permissoes = "CRIAR, LER, ALTERAR, EXCLUIR"
};

var usuario = new Usuario
{
    Nome = "Breno Rios",
    Senha = "123",
    Telefone = "999999999",
    Perfil = new List<Perfil>(){
        perfil
    },
    Sistemas = new List<Sistemas>()
};

var endereco = new Endereco
{
    Logradouro = "Rua das Flores",
    Numero = "123",
    Bairro = "Jardim das Acácias",
    Cidade = "São Paulo",
    Estado = "SP",
    Cep = "01234-567",
    Complemento = "Apto 101",
    Usuario = usuario
};

var sistema = new Sistemas
{
    Descricao = "ResTIConnect",
    DataHoraInicioIntegracao = DateTime.Now,
    EnderecoEntrada = "http://localhost:5000",
    EnderecoSaida = "http://localhost:5001",
    Protocolo = "http",
    Status = "ATIVO",
    Tipo = "API",
    Usuarios = new List<Usuario>(){
        usuario
    }
};

var evento = new Evento
{
    Codigo = "123",
    Conteudo = "Conteudo do evento",
    DataHoraOcorrencia = DateTime.Now,
    Descricao = "Descricão do evento",
    Tipo = "ALERTA",
    Sistemas = new List<Sistemas>(){
        sistema
    },
};

dbContext.AddRange(usuario, sistema, evento, endereco);
dbContext.SaveChanges();

usuario = dbContext.Usuarios.FirstOrDefault();
Console.WriteLine($"Usuario: {usuario.Nome}, {usuario.Senha}, {usuario.Telefone}");
Console.WriteLine($"Perfil: {usuario.Perfil.FirstOrDefault()?.Descricao}");
Console.WriteLine($"Endereco: {endereco.Logradouro}, {endereco.Numero}, {endereco.Bairro}, {endereco.Cidade}, {endereco.Estado}, {endereco.Cep}, {endereco.Complemento}");

Console.WriteLine();

sistema = dbContext.Sistemas.FirstOrDefault();
Console.WriteLine($"Sistema: {sistema.Descricao}, {sistema.DataHoraInicioIntegracao}, {sistema.EnderecoEntrada}, {sistema.EnderecoSaida}, {sistema.Protocolo}, {sistema.Status}, {sistema.Tipo}");

Console.WriteLine();

evento = dbContext.Eventos.FirstOrDefault();
Console.WriteLine($"Evento: {evento.Codigo}, {evento.Conteudo}, {evento.DataHoraOcorrencia}, {evento.Descricao}, {evento.Tipo}");
