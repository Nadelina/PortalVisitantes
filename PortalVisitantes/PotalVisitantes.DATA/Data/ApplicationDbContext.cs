using PortalVisitantes.DATA.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace PortalVisitantes.DATA.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Catalogo> Catalogos { get; set; } = null!;
		public DbSet<Visitantes> Visitantes { get; set; } = null!;

	}
}