using AutoMapper;
using PortalVisitantes.API.Commands.Catalogo;
using PortalVisitantes.API.Commands.Visitante;
using PortalVisitantes.DATA.Data.Entities;

namespace PortalVisitantes.API.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile() { 
			CreateMap<Catalogo, CrearCatalogoCommand>().ReverseMap();
			CreateMap<Visitantes, CrearVisitanteCommand>().ReverseMap();
		}
	}
}
