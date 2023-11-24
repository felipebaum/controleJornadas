using System.ComponentModel.DataAnnotations;

namespace controleJornadas.Models
{
    public class Bases
    {
        [Key]
        public int Idbase { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
        [MaxLength(200)]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
        [MaxLength(5)]
        public string Sigla
        {
            get; set;
        }
    }
}