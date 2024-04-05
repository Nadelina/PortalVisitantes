using Microsoft.AspNetCore.Mvc;
using PortalVisitantes.Presentation.Models;
using System.Text.Json;

namespace PortalVisitantes.Presentation.Controllers
{
	public class CatalogoController : Controller
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiBaseUrl;

		public CatalogoController(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiBaseUrl = configuration["UrlSettings:ApiBaseUrl"];
		}
		public async Task<IActionResult> Index()
		{
			var response = await _httpClient.GetAsync($"{_apiBaseUrl}api/Catalogo");

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var lista = JsonSerializer.Deserialize<List<CatalogoViewModel>>(content);
				return View(lista);
			}

			return NotFound();
		}

		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Crear(CatalogoViewModel item)
		{

			var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}api/Catalogo/", item);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Catalogo");
			}

			ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el item");
			return View(item);

		}
	}
}
