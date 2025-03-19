using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evento
    {
        public int id { get; set; }
        public DateTime DataEvento { get; set; }
        public int QtdeAdultos { get; set; }
        public int QtdeCriancas { get; set; }
        public int ValorTotal { get; set; }
        public String Status { get; set; } = String.Empty;

        public int idCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int idTipoEvento { get; set; }
        public virtual TipoEvento TipoEvento { get; set; }

        public int idFormaPagamento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
    }
}
