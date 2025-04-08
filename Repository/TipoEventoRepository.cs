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

        public IEnumerable<TipoEvento> GetAll()
        {
            return this.contexto.Set<TipoEvento>().ToList().OrderBy(p => p.Descricao);
        }
    }
}
