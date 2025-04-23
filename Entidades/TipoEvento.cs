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
        public String Descricao { get; set; } = String.Empty;
        public Decimal Valor { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; } = new HashSet<Evento>();
    }
}
