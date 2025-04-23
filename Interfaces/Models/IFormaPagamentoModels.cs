using Projeto2025.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IFormaPagamentoModels
    {
        FormaPagamentoDTO save(FormaPagamentoDTO dTO);
        IEnumerable<FormaPagamentoDTO> GetAll();
        void delete(int id);
        FormaPagamentoDTO GetFormaPagamento(int id);
    }
}
