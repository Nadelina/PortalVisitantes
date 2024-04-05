using System.ComponentModel.DataAnnotations;

namespace PortalVisitantes.API.DTOS
{
	public class VisitanteDto
	{
		public int Dui { get; set; }
		public string Nombre { get; set; }
		public string Email { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public int Telefono { get; set; }
		public string Generacion { get; set; } = string.Empty;
	}
}
