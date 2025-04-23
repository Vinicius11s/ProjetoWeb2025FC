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
        Evento GetEvento(int id);
        IEnumerable<Evento> GetAll();
        void delete(int id);
    }
}
