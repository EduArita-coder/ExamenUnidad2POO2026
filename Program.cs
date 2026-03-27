<<<<<<< HEAD
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
=======
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
>>>>>>> 9e82fd35a20b5c3dc92de330462730307815c6bf
