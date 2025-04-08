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


        [Display(Name = "Data Evento")]
        [Required(ErrorMessage = "A Data do Evento é obrigatória")]
        public DateTime DataEvento { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O Tipo Evento é obrigatório")]
        public int TipoEventoId { get; set; }

     
        public String Descricao { get; set; } = String.Empty;
    }
}
