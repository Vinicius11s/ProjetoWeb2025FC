using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface ILoginRepository
    {
        Login recuperar(Expression<Func<Login, bool>> expression);     
    }
}
