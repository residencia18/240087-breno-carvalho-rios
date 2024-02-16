
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
            if(sistema.UsuariosId.Count < 1)
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
                _sistema.Usuarios!.Add(_usuarioService.GetByDbId(usuarioId));
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
                    Eventos = _eventoService.GetBySistemaId(s.SistemaId),
                    Usuarios = _usuarioService.GetBySistemaId(s.SistemaId)
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
                    Eventos = s.Eventos!.Select(e => new EventoViewModel
                    {
                        EventoId = e.EventoId,
                        Tipo = e.Tipo,
                        Descricao = e.Descricao,
                        Codigo = e.Codigo,
                        Conteudo = e.Conteudo,
                        DataHoraOcorrencia = e.DataHoraOcorrencia
                    }).ToList(),
                    Usuarios = s.Usuarios!.Select(u => new UsuarioViewModel
                    {
                        UsuarioId = u.UsuarioId,
                        Nome = u.Nome,
                        Senha = u.Senha,
                        Email = u.Email,
                        Apelido = u.Apelido ?? "",
                        Telefone = u.Telefone,
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
                    Eventos = _eventoService.GetBySistemaId(id),
                    Usuarios = _usuarioService.GetBySistemaId(id),
                };
            }
            throw new SistemaNotFoundException();
        }

        public List<SistemaViewModel> GetUserById(int usuarioId)
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
                    Eventos = s.Eventos!.Select(e => new EventoViewModel
                    {
                        EventoId = e.EventoId,
                        Tipo = e.Tipo,
                        Descricao = e.Descricao,
                        Codigo = e.Codigo,
                        Conteudo = e.Conteudo,
                        DataHoraOcorrencia = e.DataHoraOcorrencia
                    }).ToList(),
                    Usuarios = s.Usuarios!.Select(u => new UsuarioViewModel
                    {
                        UsuarioId = u.UsuarioId,
                        Nome = u.Nome,
                        Senha = u.Senha,
                        Email = u.Email,
                        Apelido = u.Apelido ?? "",
                        Telefone = u.Telefone,
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
