using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace ResTIConnect.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly ResTIConnectDbContext _context;

        public EventoService(ResTIConnectDbContext context)
        {
            _context = context;
        }

        public int Create(NewEventoInputModel evento)
        {
            var novoEvento = new Evento
            {
                Tipo = evento.Tipo,
                Descricao = evento.Descricao,
                Codigo = evento.Codigo,
                Conteudo = evento.Conteudo,
                DataHoraOcorrencia = evento.DataHoraOcorrencia,
                Sistemas = new List<Sistema>()
            };

            _context.Eventos.Add(novoEvento);
            _context.SaveChanges();

            return novoEvento.EventoId;
        }

        public void Delete(int id)
        {
            _context.Eventos.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public List<EventoViewModel> GetAll()
        {
            var eventos = _context.Eventos
                .Select(e => new EventoViewModel
                {
                    EventoId = e.EventoId,
                    Tipo = e.Tipo,
                    Descricao = e.Descricao,
                    Codigo = e.Codigo,
                    Conteudo = e.Conteudo,
                    DataHoraOcorrencia = e.DataHoraOcorrencia
                })
                .ToList();

            return eventos;
        }

        public EventoViewModel GetById(int id)
{
        var evento = _context.Eventos.Find(id);
        if (evento != null)
        {
                return new EventoViewModel
                {
                    EventoId = evento.EventoId,
                    Tipo = evento.Tipo,
                    Descricao = evento.Descricao,
                    Codigo = evento.Codigo,
                    Conteudo = evento.Conteudo,
                    DataHoraOcorrencia = evento.DataHoraOcorrencia
                };
            }
            throw new EventoNotFoundException();
        }


        public void Update(int id, NewEventoInputModel evento)
        {
            var eventoExistente = GetByDbId(id);
            if (eventoExistente != null)
            {
                eventoExistente.Tipo = evento.Tipo;
                eventoExistente.Descricao = evento.Descricao;
                eventoExistente.Codigo = evento.Codigo;
                eventoExistente.Conteudo = evento.Conteudo;
                eventoExistente.DataHoraOcorrencia = evento.DataHoraOcorrencia;

                _context.SaveChanges();
            }
        }

        public Evento GetByDbId(int id)
        {
            var evento = _context.Eventos.Find(id);
            if (evento == null)
            {
                throw new EventoNotFoundException();
            }
            return evento;
        }
    }
}
