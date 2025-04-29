using Entidades;
using Infraestrutura.Contexto;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private EmpresaContexto contexto;
        public FormaPagamentoRepository(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public FormaPagamento addFormaPagamento (FormaPagamento formaPagamento)
        {
            this.contexto.Set<FormaPagamento>().Add(formaPagamento);
            this.contexto.SaveChanges();
            return formaPagamento;
        }
        public FormaPagamento updateFormaPagamento (FormaPagamento formaPagamento)
        {
            this.contexto.Set<FormaPagamento>().Update(formaPagamento);
            this.contexto.SaveChanges();
            return formaPagamento;
        }

        public IEnumerable<FormaPagamento> GetAll()
        {
            return this.contexto.Set<FormaPagamento>().ToList().OrderBy(p => p.Descricao);//descricao
        }
        public FormaPagamento GetFormaPagamento(int id)
        {
            return this.contexto.Set<FormaPagamento>().Find(id);
        }

        public void delete(int id)
        {
            var obj = this.contexto.Set<FormaPagamento>().Find(id);
            if (obj != null)
            {
                this.contexto.Remove(obj);
                this.contexto.SaveChanges();
            }
        }
    }
}

