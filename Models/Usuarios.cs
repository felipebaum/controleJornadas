using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;

namespace controleJornadas.Models
{
    public class Usuarios
    {
		[Key]
		public int IdUsuario { get; set; }

		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
		[MaxLength(500)]
		public string NomeFuncionario { get; set; }
		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
		[MaxLength(40)]
		public string login { get; set; }
		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatóio")]
		[MaxLength(40)]
		public string Password { get; set; }

		//adicionar opçao para selecionar as siglas que ele tem acesso
	}
}
