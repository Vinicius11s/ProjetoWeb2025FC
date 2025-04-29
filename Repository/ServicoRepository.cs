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
    public class ServicoRepository : IServicoRepository
    {
        private EmpresaContexto contexto;
        public ServicoRepository(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public Servico addServico(Servico servico)
        {
            this.contexto.Set<Servico>().Add(servico);
            this.contexto.SaveChanges();
            return servico;
        }
        public Servico updateServico(Servico servico)
        {
            this.contexto.Set<Servico>().Update(servico);
            this.contexto.SaveChanges();
            return servico;
        }
 
        public IEnumerable<Servico> GetAll()
        {
            return this.contexto.Set<Servico>().ToList().OrderBy(p => p.NomeServico);
        }
        public Servico GetServico(int id)
        {
            return this.contexto.Set<Servico>().Find(id);
        }

        public void delete(int id)
        {
            var obj = this.contexto.Set<Servico>().Find(id);
            if (obj != null)
            {
                this.contexto.Remove(obj);
                this.contexto.SaveChanges();
            }
        }
    }
}

