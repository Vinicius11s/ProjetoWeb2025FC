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
        Cliente addCliente(Cliente cliente);
        IEnumerable<Cliente> GetAll();
        void delete(int id);
        Cliente GetCliente(int id);
        Cliente updateCliente(Cliente cliente);
        Cliente recuperar(Func<Cliente, bool> expressao);
    }
}
