using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projeto2025.DTOs
{
    public class EventoDTO
    {
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A Descrição do Evento é obrigatória")]
        public String Descricao { get; set; } = String.Empty;

        [Display(Name = "Tipo Evento")]
        [Required(ErrorMessage = "O Tipo Evento é obrigatório")]
        public int idTipoEvento { get; set; }

        [Display(Name = "Cliente / Dono da Festa")]
        public int idCliente { get; set; }

        [Display(Name = "Data Evento")]
        [Required(ErrorMessage = "A Data do Evento é obrigatória")]
        public DateTime DataEvento { get; set; }

        [Display(Name = "Quantidade de Pessoas")]
        [Required(ErrorMessage = "A Quantidade de Pessoas é obrigatória")]
        public int QuantidadePessoas { get; set; }

        [Display(Name = "Local")]
        public String Local { get; set; } = String.Empty;

        [Display(Name = "Escolha o Status do evento")]
        [Required(ErrorMessage = "o Status do evento é obrigatório")]
        public String Status { get; set; } = String.Empty;

        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        [Display(Name = "Informe a Forma de Pagamento")]
        public int idFormaPagamento { get; set; }

        public string TipoEventoDescricao { get; set; } = String.Empty;
    }
}
