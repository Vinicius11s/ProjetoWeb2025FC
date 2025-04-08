using AutoMapper;
using Entidades;
using Projeto2025.DTOs;


namespace Projeto2025.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Evento, EventoDTO>().ReverseMap();
        }
    }
}
