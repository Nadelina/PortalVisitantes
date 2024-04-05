using Microsoft.AspNetCore.Mvc;

namespace PortalVisitantes.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiBaseUrl;

		public IActionResult Index()
		{
			return View();
		}
	}
}
