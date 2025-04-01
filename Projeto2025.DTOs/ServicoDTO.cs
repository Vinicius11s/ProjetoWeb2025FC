using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Projeto2025.DTOs
{
    public class ServicoDTO
    {
        public int id { get; set; }
        public String ChurrascoTradicional { get; set; } = String.Empty;
        public String ChurrascoAmericano { get; set; } = String.Empty;
        public String JantaCompleta { get; set; } = String.Empty;
        public String Cardapio { get; set; } = String.Empty;

        public virtual ICollection<TipoEventoServico> TipoEventoServicos { get; set; } = new HashSet<TipoEventoServico>();
    }
}
