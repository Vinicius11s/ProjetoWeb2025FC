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

        public void delete(int id)
        {
            this.repository.delete(id);
        }

        public IEnumerable<EventoDTO> GetAll()
        {
            var listaEvento = this.repository.GetAll();
            var listaEveDTO =
                mapper.Map<IEnumerable<EventoDTO>>(listaEvento);
            return listaEveDTO;
        }

        public EventoDTO GetEvento(int id)
        {
            var evento = repository.GetEvento(id);
            return mapper.Map<EventoDTO>(evento);
        }

        public EventoDTO save(EventoDTO dTO)
        {
            Evento entidade = mapper.Map<Evento>(dTO);

            if (entidade.id > 0)
            {
                repository.updateEvento(entidade); // <- método de update
            }
            else
            {
                repository.addEvento(entidade); // <- método de insert
            }

            dTO = mapper.Map<EventoDTO>(entidade);
            return dTO;
        }
    }
}
