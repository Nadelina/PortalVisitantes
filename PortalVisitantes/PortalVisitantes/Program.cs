using Microsoft.EntityFrameworkCore;
using PortalVisitantes.API.Handlers;
using PortalVisitantes.DATA.Data;
using PortalVisitantes.DATA.Repositories;
using PortalVisitantes.DATA.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var urlCliente = builder.Configuration["UrlSettings:Cliente"];
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins(urlCliente).AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
		options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<VisitanteHandler>();
builder.Services.AddScoped<CatalogoHandler>();
builder.Services.AddScoped<ICatalogoRepository, CatalogoRepository>();
builder.Services.AddScoped<IVisitantesRepository, VisitantesRepository>();
builder.Services.AddScoped<SeedDb>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var dbInitializer = scope.ServiceProvider.GetRequiredService<SeedDb>();
	dbInitializer.SeedAsync().Wait();
}

app.Run();
