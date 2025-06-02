using AutoMapper;
using Entidades;
using Projeto2025.DTOs;


namespace Projeto2025.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<FormaPagamento, FormaPagamentoDTO>().ReverseMap();
            CreateMap<Servico, ServicoDTO>().ReverseMap();
            CreateMap<TipoEvento, TipoEventoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<VendaDTO, Venda>().ReverseMap();
            CreateMap<ItemVendaDTO, ItemVenda>().ReverseMap();

            CreateMap<EventoDTO, Evento>()
                .ForMember(dest => dest.TipoEvento, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Evento, EventoDTO>()
            .ForMember(dest => dest.TipoEventoDescricao,
               opt => opt.MapFrom(src => src.TipoEvento.Descricao));
        }
    }
}
