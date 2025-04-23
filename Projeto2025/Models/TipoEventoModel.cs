using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using Projeto2025.DTOs;

namespace Projeto2025.Models
{
    public class TipoEventoModel : ITipoEventoModels
    {
        private ITipoEventoRepository repository;
        private IMapper mapper;

        public TipoEventoModel(ITipoEventoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void delete(int id)
        {
            this.repository.delete(id);
        }
        public IEnumerable<TipoEventoDTO> GetAll()
        {
            var listaTipoEvento = this.repository.GetAll();
            var listaTipoEveDTO =
                mapper.Map<IEnumerable<TipoEventoDTO>>(listaTipoEvento);
            return listaTipoEveDTO;
        }
        public TipoEventoDTO GetTipoEvento(int id)
        {
            var tipoEvento = this.GetTipoEvento(id);
            return mapper.Map<TipoEventoDTO>(tipoEvento);
        }
        public TipoEventoDTO save(TipoEventoDTO dTO)
        {
            TipoEvento entidade = mapper.Map<TipoEvento>(dTO);

            if (entidade.id == 0)
            {
                repository.addTipoEvento(entidade);
            }
            else
            {
                repository.addTipoEvento(entidade);
            }

            // Sempre remapeia o objeto atualizado e retorna
            dTO = mapper.Map<TipoEventoDTO>(entidade);
            return dTO;
        }
    }
}
