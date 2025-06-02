using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venda
    {
        public int Id { get; set; } 

        public DateTime Data { get; set; } = DateTime.Now;

        public int? idFormaPagamento { get; set; }  
        public virtual FormaPagamento? FormaPagamento { get; set; }

        public virtual List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();

        public decimal Total => Itens.Sum(i => i.Quantidade * i.Valor);

    }
}
