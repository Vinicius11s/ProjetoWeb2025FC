using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int id { get; set; }
        public String NomeCompleto { get; set; } = String.Empty;
        public String Cpf { get; set; } = String.Empty;
        public String Endereco { get; set; } = String.Empty;
        public DateTime DataNascimento { get; set; }
        public string? Sexo { get; set; }
        public String Telefone { get; set; } = String.Empty;
        public String Email { get; set; } = String.Empty;

        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public virtual ICollection<Evento> Eventos { get; set; } = new HashSet<Evento>();

    }
}
