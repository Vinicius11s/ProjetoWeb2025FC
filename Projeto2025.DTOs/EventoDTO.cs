using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2025.DTOs
{
    public class EventoDTO
    {
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O Tipo Evento é obrigatório")]
        public int TipoEventoId { get; set; }


        [Display(Name = "Data Evento")]
        [Required(ErrorMessage = "A Data do Evento é obrigatória")]
        public DateTime DataEvento { get; set; }


        [Display(Name = "Quantidade de Pessoas")]
        [Required(ErrorMessage = "A Quantidade de Pessoas é obrigatória")]
        public int QtdePessoas { get; set; }


        [Display(Name = "Escolha o Status do evento")]
        [Required(ErrorMessage = "o Status do evento é obrigatório")]
        public String Status { get; set; } = String.Empty;


        [Display(Name = "Cliente / Dono da Festa")]
        [Required(ErrorMessage = "O Cliente / Dono da Festa é obrigatório")]
        public int idCliente { get; set; }


        [Display(Name = "Informe a Forma de Pagamento")]
        [Required(ErrorMessage = "A Forma de Pagamento é obrigatório")]
        public int idFormaPagamento { get; set; }






     
        public String Descricao { get; set; } = String.Empty;
    }
}
