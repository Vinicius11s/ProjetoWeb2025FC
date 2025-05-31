using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto2025.DTOs;

namespace Interfaces.Models
{
    public interface IEventoModels
    {
        EventoDTO save(EventoDTO dTO);
        IEnumerable<EventoDTO> GetAll();
        void delete(int id);
        EventoDTO GetEvento(int id);
    }
}
