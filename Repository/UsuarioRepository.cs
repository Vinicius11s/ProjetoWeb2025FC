using Entidades;
using Infraestrutura.Contexto;
using InfraEstrutura;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private EmpresaContexto contexto;

        public UsuarioRepository(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }
        public Usuario recuperar(Expression<Func<Usuario, bool>> expression)
        {
            //select * from login where(expression) parametro
            return contexto.Set<Usuario>().Where(expression).FirstOrDefault();
        }
        public Usuario add(Usuario produto)
        {
            this.contexto.Set<Usuario>().Add(produto);
            this.contexto.SaveChanges();
            return produto;
        }     
        public Usuario update(Usuario produto)
        {
            var prodaux = contexto.Set<Usuario>().Find(produto.id);



            if (prodaux != null)
            {
                contexto.Entry(prodaux).State = EntityState.Detached;
                this.contexto.Set<Usuario>().Update(produto);
                this.contexto.SaveChanges();
            }


            return produto;
        }
    }
}
