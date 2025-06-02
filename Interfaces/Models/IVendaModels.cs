using Projeto2025.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IVendaModels
    {
        IEnumerable<VendaDTO> getAll();
        VendaDTO save(VendaDTO dTO);
    }
}
