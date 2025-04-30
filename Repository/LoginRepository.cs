using Entidades;
using Infraestrutura.Contexto;
using InfraEstrutura;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LoginRepository : ILoginRepository
    {
        private EmpresaContexto contexto;

        public LoginRepository(EmpresaContexto contexto)
        {
            this.contexto = contexto;
        }

        public Login recuperar(Expression<Func<Login, bool>> expression)
        {
            //select * from login where(expression) parametro
            return contexto.Set<Login>().Where(expression).FirstOrDefault();
        }
    }
}
