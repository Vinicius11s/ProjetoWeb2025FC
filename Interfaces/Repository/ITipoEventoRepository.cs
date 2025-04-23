using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces.Repository
{
    public interface ITipoEventoRepository
    {
        TipoEvento addTipoEvento (TipoEvento tipoEvento);
        TipoEvento updateTipoEvento (TipoEvento tipoEvento);
        TipoEvento GetTipoEvento(int id);
        IEnumerable<TipoEvento> GetAll();
        void delete(int id);
    }
}
