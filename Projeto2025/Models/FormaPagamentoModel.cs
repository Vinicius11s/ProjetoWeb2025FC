using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using Projeto2025.DTOs;

namespace Projeto2025.Models
{
    public class FormaPagamentoModel : IFormaPagamentoModels
    {
        private IFormaPagamentoRepository repository;
        private IMapper mapper;
        public FormaPagamentoModel(IFormaPagamentoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IEnumerable<FormaPagamentoDTO> GetAll()
        {
            return mapper.Map<IEnumerable<FormaPagamentoDTO>>(repository.GetAll());
        }
        public FormaPagamentoDTO save(FormaPagamentoDTO dTO)
        {
            FormaPagamento entidade = mapper.Map<FormaPagamento>(dTO);

            if (entidade.id == 0)
            {
                repository.addFormaPagamento(entidade);
            }
            else
            {
                repository.updateFormaPagamento(entidade);
            }

            // Sempre remapeia o objeto atualizado e retorna
            dTO = mapper.Map<FormaPagamentoDTO>(entidade);
            return dTO;
        }
        public void delete(int id)
        {
            this.repository.delete(id);

        }
        public FormaPagamentoDTO GetFormaPagamento(int id)
        {
            var forma = this.repository.GetFormaPagamento(id);
            return mapper.Map<FormaPagamentoDTO>(forma);
           
        }
    }
}
