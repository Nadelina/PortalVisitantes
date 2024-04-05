using System.Text.Json.Serialization;

namespace PortalVisitantes.Presentation.Models
{
	public class CatalogoViewModel
	{
		[JsonPropertyName("nombre")]
		public string Nombre { get; set; }
		[JsonPropertyName("url")]
		public string Url { get; set; }
	}
}
