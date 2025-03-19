using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoEvento
    {
        public int id { get; set; }
        public String Aniversario { get; set; } = String.Empty;
        public String AniversarioInfantil { get; set; } = String.Empty;
        public String Casamento { get; set; } = String.Empty;
        public String Corporativo { get; set; } = String.Empty;

        public virtual ICollection<Evento> Eventos { get; set; } = new HashSet<Evento>();
        public virtual ICollection<TipoEventoServico> TipoEventoServicos { get; set; } = new HashSet<TipoEventoServico>();


    }
}
