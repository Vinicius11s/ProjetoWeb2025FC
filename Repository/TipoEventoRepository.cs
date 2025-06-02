using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Infraestrutura.Contexto;
using Interfaces.Repository;

namespace Repository
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private EmpresaContexto contexto;
        public TipoEventoRepository(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }
        public TipoEvento addTipoEvento(TipoEvento tipoEvento)
        {
            this.contexto.Set<TipoEvento>().Add(tipoEvento);
            this.contexto.SaveChanges();
            return tipoEvento;
        }
        public TipoEvento updateTipoEvento(TipoEvento tipoEvento)
        {
            this.contexto.Set<TipoEvento>().Update(tipoEvento);
            this.contexto.SaveChanges();
            return tipoEvento;
        }    
        public IEnumerable<TipoEvento> GetAll()
        {
            return this.contexto.Set<TipoEvento>().ToList().OrderBy(p => p.Descricao);
        }
        public TipoEvento GetTipoEvento(int id)
        {
            return this.contexto.Set<TipoEvento>().Find(id);
        }
        public void delete(int id)
        {
            var obj = this.contexto.Set<TipoEvento>().Find(id);
            if (obj != null)
            {
                this.contexto.Remove(obj);
                this.contexto.SaveChanges();
            }
        }
    }
}
