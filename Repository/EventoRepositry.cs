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
        public Evento updateEevnto(Evento servico)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<Evento> GetAll()
        {
            return this.contexto.Set<Evento>().ToList().OrderBy(e => e.id);
        }

        public Evento GetEvento(int id)
        {
            return this.contexto.Set<Evento>().Find(id);
        }

        public void delete(int id)
        {
            var obj = contexto.Set<Evento>().Find(id);
            if(obj != null)
            {
                this.contexto.Remove(obj);
                this.contexto.SaveChanges();
            }
        }
    }
}
