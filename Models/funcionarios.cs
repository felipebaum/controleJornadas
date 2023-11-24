using System.ComponentModel.DataAnnotations;

namespace controleJornadas.Models
{
    public class funcionarios
    {
        public int id { get; set; }
		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
		[MaxLength(200)]
		public string nome { get; set; }
		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
		[MaxLength(400)]
		public string cargo { get; set; }
		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
		[MaxLength(200)]
		public DateOnly dataAdmissao { get; set; }
		public ICollection<Bases> Bases { get; set; }
		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
		[MaxLength(200)]
		public string codPix { get; set; }
		

		public ICollection<funcionarios> Nome { get; set; }


	}
}
