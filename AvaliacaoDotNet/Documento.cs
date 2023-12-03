using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoDotNet
{
    public class Documento
    {
        public DateTime? DataHoraModificacao { get; set; }
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        // Constructor que inicializa las propiedades Tipo y Descricao
        public Documento()
        {
            Tipo = string.Empty; // O cualquier valor predeterminado que desees
            Descricao = string.Empty; // O cualquier valor predeterminado que desees
        }
    }
}
