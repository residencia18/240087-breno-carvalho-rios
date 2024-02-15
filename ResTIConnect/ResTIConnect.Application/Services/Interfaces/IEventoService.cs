using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IEventoService 
    {
        EventoViewModel GetById(int id);
        List<EventoViewModel> GetByTipo(string tipo);
        List<EventoViewModel> GetByUsuarioId(int usuarioId);
        List<EventoViewModel> GetByDataHoraOcorrencia(DateTimeOffset dataHoraOcorrencia);
        List<EventoViewModel> GetBySistemaId(int sistemaId);
        int Create(NewEventoInputModel evento);
        void Update(int id, NewEventoInputModel evento);
        void Delete(int id);
    }
}
