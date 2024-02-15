using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure.Context;
using System;
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
          var evento = _context.Eventos.Find(id);
          if (evento != null)
          {
             _context.Eventos.Remove(evento);
             _context.SaveChanges();
          }
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
            return null;
        }

        public void Update(int id, NewEventoInputModel evento)
        {
            var eventoExistente = GetById(id);
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
    }
}
