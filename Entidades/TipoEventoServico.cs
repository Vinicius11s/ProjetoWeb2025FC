using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoEventoServico
    {
        public int TipoEventoId { get; set; }
        public TipoEvento TipoEvento { get; set; }

        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}

