using System;
using System.Collections.Generic;
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

        public int idServico { get; set; }
        public virtual Servico? Servico { get; set; }

        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
