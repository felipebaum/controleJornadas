namespace controleJornadas.Models
{
    public class Jornadas

    {
		public int id { get; set; }
		public ICollection<funcionarios> Nome { get; set; }
		public DateOnly Date { get; set; }
		public string HrInicio { get; set; }
		public string HrFim { get; set; }
		public string Turno { get; set; }
		public float Valor { get; set; }




	}
}
