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

        public IEnumerable<ServicoDTO> getAll()
        {
            var listaServico = this.repository.GetAll();
            var listaSerDTO =
                mapper.Map<IEnumerable<ServicoDTO>>(listaServico);
            return listaSerDTO;
        }

        public IEnumerable<ServicoDTO> GetAll()
        {
            return mapper.Map<IEnumerable<ServicoDTO>>(repository.GetAll());
        }

        public ServicoDTO GetServico(int id)
        {
            throw new NotImplementedException();
        }

        public ServicoDTO save(ServicoDTO dTO)
        {
            Servico entidade = mapper.Map<Servico>(dTO);
            repository.addServico(entidade);
            dTO = mapper.Map<ServicoDTO>(entidade);
            return dTO;
        }
    }
}
