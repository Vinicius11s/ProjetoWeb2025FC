using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FormaPagamento
    {
        public int id { get; set; }
        public int Credito { get; set; }
        public int Debito { get; set; }
        public int Dinheiro { get; set; } 
        public int Pix { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; } = new HashSet<Evento>();
    }
}
