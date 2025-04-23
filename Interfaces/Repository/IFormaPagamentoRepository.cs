using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IFormaPagamentoRepository
    {
        FormaPagamento addFormaPagamento (FormaPagamento formaPagamento);
        FormaPagamento updateFormaPagamento (FormaPagamento formaPagamento);
        FormaPagamento GetFormaPagamento(int id);
        IEnumerable<FormaPagamento> GetAll();
        void delete(int id);
    }
}
