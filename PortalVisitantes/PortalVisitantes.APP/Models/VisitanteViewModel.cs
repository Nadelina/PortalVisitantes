using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortalVisitantes.Presentation.Models
{
	public class VisitanteViewModel
	{
		[JsonPropertyName("dui")]
		public int Dui { get; set; }
		[JsonPropertyName("nombre")]
		public string Nombre { get; set; }
		[JsonPropertyName("email")]
		public string Email { get; set; }
		[JsonPropertyName("fechanacimiento")]
		public DateTime FechaNacimiento { get; set; }
		[JsonPropertyName("telefono")]
		public int Telefono { get; set; }
		[JsonPropertyName("generacion")]
		public string Generacion { get; set; } = string.Empty;
	}
}
