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
        Evento addEvento (Evento servico);
        Evento updateEevnto (Evento servico);
        IEnumerable<Evento> GetAll();
        Evento GetEvento(int id);
        void delete(int id);
    }
}
