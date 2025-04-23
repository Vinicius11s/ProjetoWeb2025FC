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
        public String ValorServico { get; set; } = String.Empty ;
        public String QtdeProfissionais { get; set; } = String.Empty;
        public String Cardapio { get; set; } = String.Empty;
    }
}
