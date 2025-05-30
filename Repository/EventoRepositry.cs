using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Infraestrutura.Contexto;
using Interfaces;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

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
        public Evento updateEevnto(Evento evento)
        {
            var eventoaux = contexto.Set<Evento>().Find(evento.id);

            if (eventoaux != null)
            {
                contexto.Entry(eventoaux).State = EntityState.Detached;
                this.contexto.Set<Evento>().Update(evento);
                this.contexto.SaveChanges();
            }
            return evento;
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
