

using PortalVisitantes.DATA.Data;
using PortalVisitantes.DATA.Data.Entities;
using PortalVisitantes.DATA.Repositories.Interfaces;

namespace PortalVisitantes.DATA.Repositories
{
	public class VisitantesRepository : GenericRepository<Visitantes>, IVisitantesRepository
	{ 
		public VisitantesRepository(ApplicationDbContext context) : base(context) { }

		public async Task<Visitantes> ObtenerPorDuiAsync(int dui) =>
		   await context.Visitantes.FindAsync(dui);

		public async Task<Visitantes> ObtenerPorIdAsync(int id) =>
		   await context.Visitantes.FindAsync(id);
		
	}
}
