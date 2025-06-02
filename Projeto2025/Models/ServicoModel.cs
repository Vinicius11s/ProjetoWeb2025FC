using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using Projeto2025.DTOs;

namespace Projeto2025.Models
{
    public class ServicoModel : IServicoModels
    {
        private IServicoRepository repository;
        private IMapper mapper;

        public ServicoModel(IServicoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void delete(int id)
        {
            this.repository.delete(id);

        }
        public IEnumerable<ServicoDTO> GetAll()
        {
            return mapper.Map<IEnumerable<ServicoDTO>>(repository.GetAll()); ;
        }  
        public ServicoDTO GetServico(int id)
        {
            var servico = this.repository.GetServico(id);
            return mapper.Map<ServicoDTO>(servico);
        }
        public ServicoDTO save(ServicoDTO dTO)
        {
            Servico entidade = mapper.Map<Servico>(dTO);
            if (entidade.id == 0)
            {
                repository.addServico(entidade);
            }
            else
            {
                repository.updateServico(entidade);
            }

            dTO = mapper.Map<ServicoDTO>(entidade);
            return dTO;
        }
    }
}
