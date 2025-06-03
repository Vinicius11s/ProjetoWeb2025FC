using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemVenda
    {
        public int Id { get; set; }

        public int idVenda { get; set; }
        public virtual Venda? Venda { get; set; }

        public int idEvento { get; set; }
        public virtual Evento? Evento { get; set; }

        [ForeignKey("idServico")]
        public int idServico { get; set; }
        public virtual Servico? Servico { get; set; }

        public decimal ValorUnitario { get; set; } 
        public int QuantidadePessoas { get; set; } 

        public decimal ValorTotal => ValorUnitario * QuantidadePessoas;
    }
}
