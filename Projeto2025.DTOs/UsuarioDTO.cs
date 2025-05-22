using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2025.DTOs
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public String Nome { get; set; } = String.Empty;
        public String email { get; set; } = String.Empty;
        public String password { get; set; } = String.Empty;
    }
}
