using Microsoft.EntityFrameworkCore;
using Parcial_1.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.

builder.Services.AddControllers();

// Registrar el DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar el SeederDB
builder.Services.AddTransient<SeederDB>();

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ejecutar el Seeder para poblar la base de datos
SeedData(app);

void SeedData(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetRequiredService<SeederDB>();
        seeder.SeedAsync().Wait();  // Ejecuta el Seeder de forma sincrónica
    }
}

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Habilitar CORS
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.Run();
