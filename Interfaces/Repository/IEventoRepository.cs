using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces.Repository
{
    public interface IEventoRepository
    {
        IEnumerable<Evento> getAll();
        Evento addEvento(Evento evento);
    }
}
