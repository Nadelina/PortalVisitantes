using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalVisitantes.API.Commands.Catalogo;
using PortalVisitantes.API.Handlers;
using PortalVisitantes.DATA.Data.Entities;
using System.Reflection.Metadata;

namespace PortalVisitantes.API.Controllers
{
	[Route("api/[controller]")]
	public class CatalogoController : Controller
	{
		private readonly CatalogoHandler _catalogoHandler;

		public CatalogoController(CatalogoHandler catalogoHandler)
		{
			_catalogoHandler = catalogoHandler;
		}
		[HttpGet]
		public async Task<ActionResult<Catalogo>> ObtenerListado()
		{
			var catalogo = await _catalogoHandler.ObtenerListado();
			return Ok(catalogo);
		}

		[HttpPost]
		public async Task<IActionResult> CrearItem([FromBody] CrearCatalogoCommand command)
		{
			await _catalogoHandler.CrearItemAsync(command);
			return Ok();
		}
	}
}
