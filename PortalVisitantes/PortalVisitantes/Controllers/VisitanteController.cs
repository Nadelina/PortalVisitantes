using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalVisitantes.API.Commands.Catalogo;
using PortalVisitantes.API.Commands.Visitante;
using PortalVisitantes.API.Handlers;
using PortalVisitantes.DATA.Data.Entities;

namespace PortalVisitantes.API.Controllers
{
	[Route("api/[controller]")]
	public class VisitanteController : Controller
	{
		private readonly VisitanteHandler _visitanteHandler;

		public VisitanteController(VisitanteHandler visitanteHandler)
		{
			_visitanteHandler = visitanteHandler;
		}
		[HttpGet]
		public async Task<ActionResult<Visitantes>> ObtenerListado()
		{
			var lista = await _visitanteHandler.ObtenerListado();
			return Ok(lista);
		}

		[HttpPost]
		public async Task<IActionResult> RegistarVisitante([FromBody] CrearVisitanteCommand command)
		{
			await _visitanteHandler.CrearVisitaAsync(command);
			return Ok();
		}
	}
}
