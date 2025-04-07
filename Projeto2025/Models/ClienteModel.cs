using Projeto2025.DTOs;
using Interfaces;
using Interfaces.Models;
using Interfaces.Repository;
using AutoMapper;
using Entidades;

namespace Projeto2025.Models
{
    public class ClienteModel : IClienteModels
    {
        private IClienteRepository repository;
        private IMapper mapper;
        public ClienteModel(IClienteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IEnumerable<ClienteDTO> GetAll()
        {
            return mapper.Map<IEnumerable<ClienteDTO>>(repository.GetAll());
        }
        public ClienteDTO save(ClienteDTO dTO)
        {
            Cliente entidade = mapper.Map<Cliente>(dTO);
            repository.addCliente(entidade);
            dTO = mapper.Map<ClienteDTO>(entidade);
            return dTO;
        }
    }
}
