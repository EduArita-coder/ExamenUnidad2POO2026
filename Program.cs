using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ExamenUnidad2.Database;
using ExamenUnidad2.Services;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container 
builder.Services.AddDbContext<PersonDBContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios
builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();
builder.Services.AddTransient<IPlanillaService, PlanillaService>();
builder.Services.AddTransient<IDetallePlanillaService, DetallePlanillaService>();

builder.Services.AddOpenApi();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization(); 

app.UseHttpsRedirection(); 

app.MapControllers(); 

app.Run();
