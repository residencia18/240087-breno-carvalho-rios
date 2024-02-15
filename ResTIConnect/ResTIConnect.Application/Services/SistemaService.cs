
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
        public SistemaService(ResTIConnectDbContext context)
        {
            _context = context;
        }
        public int Create(NewSistemaInputModel sistema)
        {
            var _sistema = new Sistema
            {
                Descricao = sistema.Descricao,
                Tipo = sistema.Tipo
            };

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
                    Tipo = s.Tipo
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
                    Tipo = s.Tipo
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
                    Tipo = sistema.Tipo
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
                    Tipo = s.Tipo
                })
                .ToList();

            return sistemas;
        }
        public void AdicionaSistemaAoEvento(int EventoId, int sistemaId)
        {
            var _evento = _context.Eventos.Find(EventoId);
            if (_evento is null)
                throw new EventoNotFoundException();

            var _sistema = _context.Sistemas.Find(sistemaId);
            if (_sistema is null)
                throw new SistemaNotFoundException();

            _evento.Sistemas!.Add(_sistema);
            _context.SaveChanges();
        }

        public void Update(int id, NewSistemaInputModel entity)
        {
            var _sistema = GetByDbId(id);
            _sistema.Descricao = entity.Descricao;
            _sistema.Tipo = entity.Tipo;
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
