using System.ComponentModel.DataAnnotations;

namespace controleJornadas.Models
{
    public class Jornadas

    {
        private const string ErroPadrao = "O campo {0} é de preenchimento obrigatóio";

        public int id { get; set; }

        [Required(ErrorMessage = ErroPadrao)]
        [Display(Name = "Data inicio da Jornada")]
        public DateTime HrInicio { get; set; }

        [Required(ErrorMessage = ErroPadrao)]
        [Display(Name = "Data inicio da Jornada")]
        public DateTime HrFim { get; set; }

        [Required(ErrorMessage = ErroPadrao)]
        [Display(Name = "Turno")]
        public string Turno { get; set; }

        [Display(Name = "Valor R$")]
        [Required(ErrorMessage = ErroPadrao)]
        public float Valor { get; set; }




	}
}
