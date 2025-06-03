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
        private IEventoRepository eventoRepository;

        public VendaModels(IVendaRepository repository, IMapper mapper,
            IServicoRepository servicoRepository, IEventoRepository eventoRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.servicoRepository = servicoRepository;
            this.eventoRepository = eventoRepository;
        }

        public IEnumerable<VendaDTO> getAll()
        {
            var lista= this.repository.getAll();
            return mapper.Map<IEnumerable<VendaDTO>>(lista);

        }

        public VendaDTO save(VendaDTO dTO)
        {
            foreach (var item in dTO.Itens)
            {
                var servico = servicoRepository.GetServico(item.idServico);
                var evento = eventoRepository.GetEvento(item.idEvento);

                item.QuantidadePessoas = evento.QuantidadePessoas;
                item.ValorUnitario = servico.ValorPorPessoa;
            }

            var venda = mapper.Map<Venda>(dTO);
            venda = this.repository.add(venda);
            return mapper.Map<VendaDTO>(venda);
        }

    }
}
