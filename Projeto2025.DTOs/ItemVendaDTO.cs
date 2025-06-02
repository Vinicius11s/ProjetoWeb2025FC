using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2025.DTOs
{
    public class ItemVendaDTO
    {
        public int idEvento { get; set; }
        public string? EventoDescricao { get; set; }

        public int idServico { get; set; }
        public string? ServicoDescricao { get; set; }

        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }  

        public decimal Subtotal => Quantidade * PrecoUnitario;
    }
}
