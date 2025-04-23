using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using Projeto2025.DTOs;

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

            if (entidade.id == 0)
            {
                repository.addCliente(entidade);
            }
            else
            {
                repository.updateCliente(entidade);
            }

            // Sempre remapeia o objeto atualizado e retorna
            dTO = mapper.Map<ClienteDTO>(entidade);
            return dTO;
        }
        public void delete(int id)
        {
            this.repository.delete(id);
      
        }
        public ClienteDTO GetCliente(int id)
        {
            var cliente = this.GetCliente(id);
            return mapper.Map<ClienteDTO>(cliente);
        }
    }
}
