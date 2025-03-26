using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Projeto2025.DTOs
{
    public class ClienteDTO
    {
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public String Nome { get; set; } = String.Empty;


        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public String Cpf { get; set; } = String.Empty;


        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone é obrigatório")]
        public String Telefone { get; set; } = String.Empty;


        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O Endereço é obrigatório")]
        public String Endereco { get; set; } = String.Empty;
    }
}
