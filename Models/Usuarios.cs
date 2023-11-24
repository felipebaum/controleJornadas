using System.ComponentModel.DataAnnotations;

namespace controleJornadas.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
		public required string Nome { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
		public ICollection<Bases> Bases { get; set; }

	}
}
