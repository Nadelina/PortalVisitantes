using PortalVisitantes.DATA.Data.Entities;

namespace PortalVisitantes.DATA.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext context;
        public SeedDb(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task SeedAsync()
        {
            await context.Database.EnsureCreatedAsync();

            // Verificar si ya existen datos
            if (!context.Catalogos.Any())
            {
                // Crear un nuevo titular de tarjeta
                var item = new Catalogo{Nombre="Wendys", Url= "https://www.wendys.com.sv/" };

                // Agregar el titular a la base de datos
                context.Catalogos.Add(item);
                // Guardar los cambios en la base de datos
                await context.SaveChangesAsync();
            }
        }
    }
}
