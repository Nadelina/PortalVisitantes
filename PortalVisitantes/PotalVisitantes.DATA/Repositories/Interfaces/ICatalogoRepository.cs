using PortalVisitantes.DATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalVisitantes.DATA.Repositories.Interfaces
{
	public interface ICatalogoRepository : IGenericRepository<Catalogo>
	{
		Task<Catalogo> ObtenerPorIdAsync(int id);

	}
}
