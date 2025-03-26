using Projeto2025.DTOs;
using Interfaces;
using Interfaces.Models;

namespace Projeto2025.Models
{
    public class ClienteModel : IClienteModels
    {
        private
        public ClienteModel()
        {
        }

        public ClienteDTO salvar(ClienteDTO clienteDTO)
        {
            return clienteDTO;
        }
    }
}
