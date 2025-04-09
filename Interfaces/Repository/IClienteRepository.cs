using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces.Repository
{
    public interface IClienteRepository
    {
        Cliente addCliente(Cliente produto);
        Cliente updateCliente(Cliente produto)
        Cliente GetCliente(int id);
        IEnumerable<Cliente> GetAll();
        void delete(int id);
        
        
    }
}
