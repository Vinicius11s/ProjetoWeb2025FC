using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Servico
    {
        public int id { get; set; }
        public String NomeServico { get; set; } = String.Empty;
        public Decimal ValorPorPessoa { get; set; }
        public int? DuracaoHoras { get; set; }
        public String Descricao { get; set; } = String.Empty;

        public List<ItemVenda> Itens { get; set; }
    }
}
