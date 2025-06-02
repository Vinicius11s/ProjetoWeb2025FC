using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Infraestrutura.Contexto;
using Infraestrutura;
using Interfaces;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private EmpresaContexto contexto;
        public ClienteRepository(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public Cliente addCliente(Cliente produto)
        {
            this.contexto.Set<Cliente>().Add(produto);
            this.contexto.SaveChanges();
            return produto;
        }
        public void delete(int id)
        {
            var obj = this.contexto.Set<Cliente>().Find(id);
            if (obj != null)
            {
                this.contexto.Remove(obj);
                this.contexto.SaveChanges();
            }
        }
        public IEnumerable<Cliente> GetAll()
        {
            return this.contexto.Set<Cliente>().ToList().OrderBy(p => p.NomeCompleto);
        }
        public Cliente GetCliente(int id)
        {
            return this.contexto.Set<Cliente>().Find(id);
        }
        public Cliente recuperar(Func<Cliente, bool> expressao)
        {
            return this.contexto.Set<Cliente>().Where(expressao).FirstOrDefault();
        }
        public Cliente updateCliente(Cliente produto)
        {
            this.contexto.Set<Cliente>().Update(produto);
            this.contexto.SaveChanges();
            return produto;
        }
       
    }
}
