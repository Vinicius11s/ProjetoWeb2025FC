using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Infraestrutura.Contexto;
using Interfaces;
using Interfaces.Repository;

namespace Repository
{
    public class EventoRepositry : IEventoReposiory
    {
        private EmpresaContexto contexto;
        public EventoRepositry( EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public IEnumerable<Evento> getAll()
        {
            return this.contexto.Set<Evento>().ToList().OrderBy(p => p.DataEvento);
        }
    }
}
