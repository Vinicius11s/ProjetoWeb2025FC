using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Usuario recuperar
            (Expression<Func<Usuario, bool>> expression);
        Usuario add(Usuario produto);
        Usuario update(Usuario produto);
    }
}
