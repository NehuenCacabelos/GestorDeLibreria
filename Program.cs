using System.Data;
using Dapper;
using GESTORDEBIBLIOTECA.Features.Libro.Repository;
using Microsoft.AspNetCore.Http.Features;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

