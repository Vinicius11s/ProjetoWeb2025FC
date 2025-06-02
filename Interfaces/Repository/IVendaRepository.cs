using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IVendaRepository
    {
        IEnumerable<Venda> getAll();
        Venda add(Venda servico);
    }
}
