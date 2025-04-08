using AutoMapper;
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

        public IEnumerable<TipoEventoDTO> GetAll()
        {
            var listaTipoEvento = this.repository.GetAll();
            var listaTipoEveDTO =
                mapper.Map<IEnumerable<TipoEventoDTO>>(listaTipoEvento);
            return listaTipoEveDTO;
        }
    }
}
