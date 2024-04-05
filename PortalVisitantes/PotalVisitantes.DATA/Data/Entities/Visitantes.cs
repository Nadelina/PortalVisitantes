using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalVisitantes.DATA.Data.Entities
{
	public class Visitantes
	{
        public int Dui { get; set; }
        public string Nombre { get; set; }
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; } 
        [DataType(DataType.PhoneNumber)]
        public int Telefono { get; set; }
    }
}
