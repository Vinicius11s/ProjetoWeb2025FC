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
    public class EventoRepositry : IEventoRepository
    {
        private EmpresaContexto contexto;
        public EventoRepositry( EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public Evento addEvento(Evento eve)
        {
            this.contexto.Set<Evento>().Add(eve);
            this.contexto.SaveChanges();
            return eve;
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> getAll()
        {
            return this.contexto.Set<Evento>().ToList().OrderBy(p => p.DataEvento);
        }

        public IEnumerable<Evento> GetAll()
        {
            throw new NotImplementedException();
        }

        public Evento GetEvento(int id)
        {
            throw new NotImplementedException();
        }

        public Evento updateEevnto(Evento servico)
        {
            throw new NotImplementedException();
        }
    }
}
