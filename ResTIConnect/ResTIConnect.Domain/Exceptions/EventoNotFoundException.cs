using System;

namespace ResTIConnect.Domain.Exceptions
{
    public class EventoNotFoundException : Exception
    {
        public EventoNotFoundException() :
           base("O evento selecionado não foi encontrado.")
        {
        }
    }
}
