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

        [Display(Name = "Valor por Pessoa")]
        [Required(ErrorMessage = "O Valor por pessoa é obrigatório")]
        public String ValorPorPessoa { get; set; } = String.Empty;

        [Display(Name = "Duração Máxima (Horas)")]
        [Required(ErrorMessage = "A Duração é obrigatória")]
        public int? DuracaoHoras { get; set; }

        [Display(Name = "Descrição")]
        public String Descricao { get; set; } = String.Empty;

    }
}
