using PortalVisitantes.DATA.Data;
using PortalVisitantes.DATA.Data.Entities;
using PortalVisitantes.DATA.Repositories.Interfaces;

namespace PortalVisitantes.DATA.Repositories
{
	public class CatalogoRepository : GenericRepository<Catalogo>, ICatalogoRepository
	{
		public CatalogoRepository(ApplicationDbContext context) : base(context)
		{
		}
		public async Task<Catalogo> ObtenerPorIdAsync(int id) =>
		   await context.Catalogos.FindAsync(id);
	}
	
}
