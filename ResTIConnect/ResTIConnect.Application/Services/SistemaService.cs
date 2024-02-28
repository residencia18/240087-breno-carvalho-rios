
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infrastructure.Context;

namespace ResTIConnect.Application.Services
{
    public class SistemaService : ISistemaService
    {
        private readonly ResTIConnectDbContext _context;
        private readonly IUsuarioService _usuarioService;
        private readonly IEventoService _eventoService;
        public SistemaService(ResTIConnectDbContext context, IUsuarioService usuarioService, IEventoService eventoService)
        {
            _context = context;
            _usuarioService = usuarioService;
            _eventoService = eventoService;
        }

        public int Create(NewSistemaInputModel sistema)
        {
            if (sistema.UsuariosId.Count < 1)
            {
                throw new EmptyUsersListException();
            }

            var _sistema = new Sistema
            {
                Descricao = sistema.Descricao,
                Tipo = sistema.Tipo,
                DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao,
                EnderecoEntrada = sistema.EnderecoEntrada,
                EnderecoSaida = sistema.EnderecoSaida,
                Protocolo = sistema.Protocolo,
                Status = sistema.Status,
                Usuarios = new List<Usuario>()
            };

            foreach (var usuarioId in sistema.UsuariosId)
            {
                var _usuario = _usuarioService.GetByDbId(usuarioId);
                _sistema.Usuarios!.Add(_usuario);
            }

            _context.Sistemas.Add(_sistema);
            _context.SaveChanges();

            return _sistema.SistemaId;
        }

        public List<SistemaViewModel> GetAll()
        {
            var sistemas = _context.Sistemas
                .Select(s => new SistemaViewModel
                {
                    SistemaId = s.SistemaId,
                    Descricao = s.Descricao,
                    Tipo = s.Tipo,
                    DataHoraInicioIntegracao = s.DataHoraInicioIntegracao,
                    EnderecoEntrada = s.EnderecoEntrada,
                    EnderecoSaida = s.EnderecoSaida,
                    Protocolo = s.Protocolo,
                    Status = s.Status,
                    Eventos = s.Eventos.Select(e => new EventoViewModel
                    {
                        EventoId = e.EventoId,
                        Codigo = e.Codigo,
                        DataHoraOcorrencia = e.DataHoraOcorrencia,
                        Descricao = e.Descricao,
                        Tipo = e.Tipo,
                        Conteudo = e.Conteudo
                    }).ToList(),
                    Usuarios = s.Usuarios.Select(u => new UsuarioViewModel
                    {
                        Nome = u.Nome,
                        Apelido = u.Apelido ?? "",
                        Email = u.Email,
                        Telefone = u.Telefone,
                        Endereco = new EnderecoViewModel
                        {
                            Bairro = u.Endereco.Bairro,
                            Cep = u.Endereco.Cep,
                            Cidade = u.Endereco.Cidade,
                            Complemento = u.Endereco.Complemento,
                            EnderecoId = u.Endereco.EnderecoId,
                            Estado = u.Endereco.Estado,
                            Logradouro = u.Endereco.Logradouro,
                            Numero = u.Endereco.Numero,
                            Pais = u.Endereco.Pais
                        }
                    }).ToList()
                })
                .ToList();

            return sistemas;
        }

        public List<SistemaViewModel> GetByEventoPeriodos(string tipoEvento, DateTime inicio)
        {
            var sistemas = _context.Sistemas
                .Where(s => s.Eventos!.Any(e => e.Tipo == tipoEvento && e.DataHoraOcorrencia >= inicio))
                .Select(s => new SistemaViewModel
                {
                    SistemaId = s.SistemaId,
                    Descricao = s.Descricao,
                    Tipo = s.Tipo,
                    DataHoraInicioIntegracao = s.DataHoraInicioIntegracao,
                    EnderecoEntrada = s.EnderecoEntrada,
                    EnderecoSaida = s.EnderecoSaida,
                    Protocolo = s.Protocolo,
                    Status = s.Status,
                    Eventos = s.Eventos.Select(e => new EventoViewModel
                    {
                        EventoId = e.EventoId,
                        Codigo = e.Codigo,
                        DataHoraOcorrencia = e.DataHoraOcorrencia,
                        Descricao = e.Descricao,
                        Tipo = e.Tipo,
                        Conteudo = e.Conteudo
                    }).ToList(),
                    Usuarios = s.Usuarios.Select(u => new UsuarioViewModel
                    {
                        Nome = u.Nome,
                        Apelido = u.Apelido ?? "",
                        Email = u.Email,
                        Telefone = u.Telefone,
                        Endereco = new EnderecoViewModel
                        {
                            Bairro = u.Endereco.Bairro,
                            Cep = u.Endereco.Cep,
                            Cidade = u.Endereco.Cidade,
                            Complemento = u.Endereco.Complemento,
                            EnderecoId = u.Endereco.EnderecoId,
                            Estado = u.Endereco.Estado,
                            Logradouro = u.Endereco.Logradouro,
                            Numero = u.Endereco.Numero,
                            Pais = u.Endereco.Pais
                        }
                    }).ToList()
                })
                .ToList();

            return sistemas;
        }

        public SistemaViewModel GetById(int id)
        {
            var sistema = _context.Sistemas.Find(id);
            if (sistema != null)
            {
                var _eventos = _eventoService.GetBySistemaId(id);
                var _usuarios = _usuarioService.GetBySistemaId(id);
                return new SistemaViewModel
                {
                    SistemaId = sistema.SistemaId,
                    Descricao = sistema.Descricao,
                    Tipo = sistema.Tipo,
                    DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao,
                    EnderecoEntrada = sistema.EnderecoEntrada,
                    EnderecoSaida = sistema.EnderecoSaida,
                    Protocolo = sistema.Protocolo,
                    Status = sistema.Status,
                    Eventos = _eventos,
                    Usuarios = _usuarios
                };
            }
            throw new SistemaNotFoundException();
        }

        public List<SistemaViewModel> GetSistemasByUserId(int usuarioId)
        {
            var sistemas = _context.Sistemas
                .Where(s => s.Usuarios!.Any(u => u.UsuarioId == usuarioId))
                .Select(s => new SistemaViewModel
                {
                    SistemaId = s.SistemaId,
                    Descricao = s.Descricao,
                    Tipo = s.Tipo,
                    DataHoraInicioIntegracao = s.DataHoraInicioIntegracao,
                    EnderecoEntrada = s.EnderecoEntrada,
                    EnderecoSaida = s.EnderecoSaida,
                    Protocolo = s.Protocolo,
                    Status = s.Status,
                    Eventos = s.Eventos.Select(e => new EventoViewModel
                    {
                        EventoId = e.EventoId,
                        Codigo = e.Codigo,
                        DataHoraOcorrencia = e.DataHoraOcorrencia,
                        Descricao = e.Descricao,
                        Tipo = e.Tipo,
                        Conteudo = e.Conteudo
                    }).ToList(),
                    Usuarios = s.Usuarios.Select(u => new UsuarioViewModel
                    {
                        Nome = u.Nome,
                        Apelido = u.Apelido ?? "",
                        Email = u.Email,
                        Telefone = u.Telefone,
                        Endereco = new EnderecoViewModel
                        {
                            Bairro = u.Endereco.Bairro,
                            Cep = u.Endereco.Cep,
                            Cidade = u.Endereco.Cidade,
                            Complemento = u.Endereco.Complemento,
                            EnderecoId = u.Endereco.EnderecoId,
                            Estado = u.Endereco.Estado,
                            Logradouro = u.Endereco.Logradouro,
                            Numero = u.Endereco.Numero,
                            Pais = u.Endereco.Pais
                        }
                    }).ToList()
                })
                .ToList();

            return sistemas;
        }

        public void AdicionaEventoAoSistema(int eventoId, int sistemaId)
        {
            var _evento = _eventoService.GetByDbId(eventoId);
            var _sistema = GetByDbId(sistemaId);

            _sistema.Eventos.Add(_evento);

            _context.Sistemas.Update(_sistema);
            _context.SaveChanges();
        }

        public void AdicionaUsuarioAoSistema(int sistemaId, int usuarioId)
        {
            var _usuario = _usuarioService.GetByDbId(usuarioId);
            var _sistema = GetByDbId(sistemaId);

            _sistema.Usuarios.Add(_usuario);

            _context.Sistemas.Update(_sistema);
            _context.SaveChanges();
        }

        public void Update(int id, NewSistemaInputModel entity)
        {
            var _sistema = GetByDbId(id);

            _sistema.Descricao = entity.Descricao;
            _sistema.Tipo = entity.Tipo;
            _sistema.DataHoraInicioIntegracao = entity.DataHoraInicioIntegracao;
            _sistema.EnderecoEntrada = entity.EnderecoEntrada;
            _sistema.EnderecoSaida = entity.EnderecoSaida;
            _sistema.Protocolo = entity.Protocolo;
            _sistema.Status = entity.Status;

            _context.Sistemas.Update(_sistema);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Sistemas.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public Sistema GetByDbId(int id)
        {
            var sistema = _context.Sistemas.Find(id);
            if (sistema == null)
            {
                throw new SistemaNotFoundException();
            }
            return sistema;
        }
    }
}
