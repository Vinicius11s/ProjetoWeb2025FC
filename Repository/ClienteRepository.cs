using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Infraestrutura.Contexto;
using InfraEstrutura;
using Interfaces;
using Interfaces.Repository;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private EmpresaContexto contexto;

        public ClienteRepository(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public Cliente addCliente(Cliente cliente)
        {
            this.contexto.Set<Cliente>().Add(cliente);
            this.contexto.SaveChanges();
            return cliente;
        }
    }
}
