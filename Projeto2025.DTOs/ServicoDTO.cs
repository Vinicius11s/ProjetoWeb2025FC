using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2025.DTOs
{
    public class ServicoDTO
    {
        public int id { get; set; }

        [Display(Name = "Nome do Serviço")]
        [Required(ErrorMessage = "O Nome do Serviço é obrigatório")]
        public String NomeServico { get; set; } = String.Empty;

        [Display(Name = "Valor do Serviço")]
        [Required(ErrorMessage = "O Valor do Serviço é obrigatório")]
        public String ValorServico { get; set; } = String.Empty;

        [Display(Name = "Quantidade de Profissionais")]
        [Required(ErrorMessage = "A Quantidade de Profissionais é obrigatória")]
        public String QtdeProfissionais { get; set; } = String.Empty;

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O Tipo Evento é obrigatório")]
        public String Cardapio { get; set; } = String.Empty;
    }
}
