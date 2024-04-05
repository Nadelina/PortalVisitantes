using PortalVisitantes.DATA.Data.Entities;

namespace PortalVisitantes.DATA.Repositories.Interfaces
{	
		public interface IVisitantesRepository : IGenericRepository<Visitantes>
	{
		Task<Visitantes> ObtenerPorIdAsync(int id);

	}
	
}
