using System.ComponentModel.DataAnnotations;

namespace controleJornadas.Models
{
    public class Bases
    {
        private const string ErroPadrao = "O campo {0} é de preenchimento obrigatóio";

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(200)]
        public string Cidade { get; set; }
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(5)]
        public string Sigla { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}