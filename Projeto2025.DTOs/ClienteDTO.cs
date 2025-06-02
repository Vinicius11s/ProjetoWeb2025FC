using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2025.DTOs
{
    public class ClienteDTO
    {
        public int id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public String NomeCompleto { get; set; } = String.Empty;

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public String Cpf { get; set; } = String.Empty;

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O Endereço é obrigatório")]
        public String Endereco { get; set; } = String.Empty;

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Sexo")]
        public String Sexo { get; set; } = String.Empty;

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone é obrigatório")]
        public String Telefone { get; set; } = String.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        public String Email { get; set; } = String.Empty;

        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public int? idEvento { get; set; }
        public virtual EventoDTO? evento { get; set; }
    }
}
