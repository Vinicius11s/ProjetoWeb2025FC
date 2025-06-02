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
        public String Descricao { get; set; } = String.Empty;
        public int idTipoEvento { get; set; }
        public virtual TipoEvento? TipoEvento { get; set; }
        public int idCliente { get; set; }
        public virtual Cliente? Cliente { get; set; }

        public DateTime DataEvento { get; set; }
        public int QuantidadePessoas { get; set; }
        public String? Local { get; set; } = String.Empty;
        public String Status { get; set; } = String.Empty;
        public string? Observacoes { get; set; }
        public decimal? ValorTotal { get; set; }

        public int idFormaPagamento { get; set; }
        public virtual FormaPagamento? FormaPagamento { get; set; }
    }
}
