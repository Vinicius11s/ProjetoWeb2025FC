using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IServicoRepository
    {
        Servico addServico(Servico servico);
        Servico updateServico(Servico servico);
        Servico GetServico(int id);
        IEnumerable<Servico> GetAll();
        void delete(int id);

    }
}
