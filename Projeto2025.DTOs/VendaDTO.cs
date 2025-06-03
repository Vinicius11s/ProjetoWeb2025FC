using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2025.DTOs
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        public List<ItemVendaDTO> Itens { get; set; } = new List<ItemVendaDTO>();

        public decimal Total => Itens.Sum(i => i.ValorTotal);

        public int? idFormaPagamento { get; set; }
        public virtual FormaPagamentoDTO? forma { get; set; }


    }
}
