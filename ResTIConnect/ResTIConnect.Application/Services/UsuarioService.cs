using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infrastructure.Context;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
namespace ResTIConnect.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ResTIConnectDbContext _context;
        private readonly IEnderecoService _enderecoservice;

        public UsuarioService(ResTIConnectDbContext context, IEnderecoService enderecoservice)
        {
            _context = context;
            _enderecoservice = enderecoservice;
        }

        public int Create(NewUsuarioInputModel usuario)
        {
            var _usuario = new Usuario
            {
                Nome = usuario.Nome,
                Apelido = usuario.Apelido,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone,
                Endereco = new Endereco
                {
                    Bairro = usuario.Endereco.Bairro,
                    Logradouro = usuario.Endereco.Logradouro,
                    Numero = usuario.Endereco.Numero,
                    Complemento = usuario.Endereco.Complemento,
                    Cidade = usuario.Endereco.Cidade,
                    Estado = usuario.Endereco.Estado,
                    Pais = usuario.Endereco.Pais,
                    Cep = usuario.Endereco.Cep,
                },
                Sistemas = new List<Sistema>()
            };

            _context.Usuarios.Add(_usuario);
            _context.SaveChanges();

            return _usuario.UsuarioId;
        }

        public List<UsuarioViewModel> GetAll()
        {
            var user = _context.Usuarios
                .Select(u => new UsuarioViewModel
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Apelido = u.Apelido ?? "",
                    Email = u.Email,
                    Senha = u.Senha,
                    Telefone = u.Telefone
                })
                .ToList();

            return user;
        }

        public Usuario GetByDbId(int id)
        {
            var user = _context.Usuarios.Find(id);

            if (user is null)
                throw new UserNotFoundException();

            return user;
        }

        public void Update(int id, NewUsuarioInputModel usuario)
        {
            var _usuarioDb = GetByDbId(id);

            _usuarioDb.Nome = usuario.Nome;
            _usuarioDb.Apelido = usuario.Apelido;
            _usuarioDb.Email = usuario.Email;
            _usuarioDb.Senha = usuario.Senha;
            _usuarioDb.Telefone = usuario.Telefone;
            _enderecoservice.Update(_usuarioDb.Endereco.EnderecoId, usuario.Endereco);

            _context.Usuarios.Update(_usuarioDb);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Usuarios.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public UsuarioViewModel? GetById(int id)
        {
            var usuario = GetByDbId(id);

            var _usuarioViewModel = new UsuarioViewModel
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Apelido = usuario.Apelido ?? "",
                Email = usuario.Email,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone
            };

            return _usuarioViewModel;
        }
    }
}
