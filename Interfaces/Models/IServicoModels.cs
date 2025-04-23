using Projeto2025.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IServicoModels
    {
        ServicoDTO save(ServicoDTO dTO);
        IEnumerable<ServicoDTO> GetAll();
        void delete(int id);

        ServicoDTO GetServico(int id);
    }
}
