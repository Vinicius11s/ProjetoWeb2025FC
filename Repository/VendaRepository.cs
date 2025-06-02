using Entidades;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infraestrutura.Contexto;

namespace Repository
{
    public class VendaRepository : IVendaRepository
    {

        private EmpresaContexto contexto;

        public VendaRepository(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public Venda add(Venda venda)
        {
            this.contexto.Set<Venda>().Add(venda);
            this.contexto.SaveChanges();
            return venda;
        }

        public IEnumerable<Venda> getAll()
        {
            return this.contexto.Set<Venda>().Include(p=>p.Itens).ThenInclude(pp=>pp.Servico).ToList();
        }
    }
}
