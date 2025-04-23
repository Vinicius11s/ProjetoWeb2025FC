using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto2025.DTOs;

namespace Interfaces.Models
{
    public interface ITipoEventoModels
    {
        TipoEventoDTO save(TipoEventoDTO dTO);
        IEnumerable<TipoEventoDTO> GetAll();
        void delete(int id);
        TipoEventoDTO GetTipoEvento(int id);
    }
}
