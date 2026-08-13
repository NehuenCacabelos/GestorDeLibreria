using Dapper;
using Microsoft.AspNetCore.Http.Features;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


// Endpoint de prueba para verificar la conexión a PostgreSQL
app.MapGet("/health-db", async (IConfiguration config) =>
{
    var connectionString = config.GetConnectionString("DefaultConnection");

    try
    {
        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();
        
        var version = await connection.QuerySingleAsync<string>("SELECT version();");
        return Results.Ok(new { Mensaje = "Conexión exitosa a PostgreSQL", Version = version });
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error al conectar a la base de datos: {ex.Message}");
    }
});


app.Run();

