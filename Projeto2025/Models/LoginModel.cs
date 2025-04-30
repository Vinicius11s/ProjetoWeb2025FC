using AutoMapper;
using Entidades;
using Interfaces.Models;
using Interfaces.Repository;
using Projeto2025.DTOs;

namespace Projeto2025.Models
{
    public class LoginModel : ILoginModels
    {
        private ILoginRepository repository;
        private IMapper mapper;

        public LoginModel(ILoginRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public LoginDTO validarLogin(string email, string password){
            var login = repository.recuperar(l => l.email == email 
                && l.password == password);
            return mapper.Map<LoginDTO>(login);
        }
    }
}
