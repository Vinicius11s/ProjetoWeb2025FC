using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using Projeto2025.DTOs;

namespace Projeto2025.Models
{
    public class UsuarioModel : IUsuarioModels
    {
        private IUsuarioRepository repository;
        private IMapper mapper;
        public UsuarioModel(IUsuarioRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public UsuarioDTO validarLogin(string email, string senha)
        {
            var usuario =
                repository.recuperar(p => p.email == email
                && p.password == senha);
            return mapper.Map<UsuarioDTO>(usuario);
        }
        public UsuarioDTO save(UsuarioDTO dTO)
        {
            Usuario entidade = mapper.Map<Usuario>(dTO);

            if (entidade.id == 0)
                repository.add(entidade);
            else
                repository.update(entidade);
            dTO = mapper.Map<UsuarioDTO>(entidade);
            return dTO;
        }
    }
}
