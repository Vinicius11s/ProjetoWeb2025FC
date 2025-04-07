using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto2025.DTOs;

namespace Interfaces.Models
{
    public interface IClienteModels
    {
        ClienteDTO save(ClienteDTO dTO);
        IEnumerable<ClienteDTO> GetAll();
    }
}
