using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using Projeto2025.DTOs;
using Repository;

namespace Projeto2025.Models
{
    public class VendaModels : IVendaModels
    {

        private IVendaRepository repository;
        private IMapper mapper;
        private IServicoRepository servicoRepository;

        public VendaModels(IVendaRepository repository, IMapper mapper,
            IServicoRepository servicoRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.servicoRepository = servicoRepository;
        }

        public IEnumerable<VendaDTO> getAll()
        {
            var lista= this.repository.getAll();
            return mapper.Map<IEnumerable<VendaDTO>>(lista);

        }

        public VendaDTO save(VendaDTO dTO)
        {
            //obter o valor do produto
            foreach (var item in dTO.Itens)
            {
                item.PrecoUnitario = 
                    servicoRepository.GetServico(item.idServico).ValorPorPessoa;
            }
            var venda = mapper.Map<Venda>(dTO);
            venda= this.repository.add(venda);
            return mapper.Map<VendaDTO>(venda);
        }
    }
}
