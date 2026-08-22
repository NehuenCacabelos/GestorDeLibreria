using System.Data;
using Npgsql;
using Dapper;
using GESTORDEBIBLIOTECA.Features.Libro.Repository;
using GESTORDEBIBLIOTECA.Features.Libro.Service;
using GESTORDEBIBLIOTECA.Features.Socio.Endopoint;
using GESTORDEBIBLIOTECA.Features.Socio.Repository;
using GESTORDEBIBLIOTECA.Features.Socio.Service;
using Microsoft.AspNetCore.Http.Features;
using GESTORDEBIBLIOTECA.Features.Excepciones;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<ISocioRepository, SocioRepository>();
builder.Services.AddScoped<ISocioService, SocioService>();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();




var app = builder.Build();
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapLibroEndpoints();
app.MapSocioEndpoints();

app.Run();

