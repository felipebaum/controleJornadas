using System.ComponentModel.DataAnnotations;

namespace controleJornadas.Models
{
    public class funcionarios
    {
        private const string ErroPadrao = "O campo {0} é de preenchimento obrigatóio";

        public int id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(200)]
		public string nome { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(400)]
		public string cargo { get; set; }

        [Display(Name = "Data de Admissão")]
        [Required(ErrorMessage = ErroPadrao)]
        public DateTime dataAdmissao { get; set; }

        [Display(Name = "Chave Pix")]
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(200)]
		public string codPix { get; set; }

		public int BasesId { get; set; }

         public Bases Bases { get; set; }

    }
}
