using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalVisitantes.API.Commands.Catalogo;
using PortalVisitantes.API.Commands.Visitante;
using PortalVisitantes.DATA.Data.Entities;
using PortalVisitantes.DATA.Repositories.Interfaces;

namespace PortalVisitantes.API.Handlers
{
	public class CatalogoHandler
	{
		private readonly ICatalogoRepository _catalogoRepository;
		private readonly IMapper _mapper;

		public CatalogoHandler(ICatalogoRepository catalogoRepository, IMapper mapper)
		{
			_catalogoRepository = catalogoRepository;
			_mapper = mapper;
		}

		public async Task<List<Catalogo>> ObtenerListado()
		{
			return await _catalogoRepository.GetAll().ToListAsync();
		}
		public async Task CrearItemAsync(CrearCatalogoCommand command)
		{
			var item = new Catalogo
			{
				Nombre = command.Nombre,
				Url = command.Url
			};

			await _catalogoRepository.CreateAsync(item);
		}
	}
}