using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using Projeto2025.DTOs;

namespace Interfaces.Models
{
    public class EventoModel : IEventoModels
    {
        private IEventoRepository repository;
        private IMapper mapper;
        public EventoModel(IEventoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IEnumerable<EventoDTO> getAll()
        {
            var listaEvento = this.repository.GetAll();
            var listaEveDTO =
                mapper.Map<IEnumerable<EventoDTO>>(listaEvento);
            return listaEveDTO;
        }
        public EventoDTO save(EventoDTO dTO)
        {
            Evento entidade = mapper.Map<Evento>(dTO);
            repository.addEvento(entidade);
            dTO = mapper.Map<EventoDTO>(entidade);
            return dTO;
        }
    }
}
