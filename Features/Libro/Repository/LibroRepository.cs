using System.Data;

namespace GESTORDEBIBLIOTECA.Features.Libro.Repository;

using Dapper;
using GESTORDEBIBLIOTECA.Feature.Libro.Model;

public class LibroRepository : ILibroRepository
{
    private readonly IDbConnection _connection;

    public LibroRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Libro>> GetAllLibros()
    {
        var query = "SELECT id, titulo, autor, isbn, cantidad_disponible AS CantidadDisponible FROM libros";
        return await _connection.QueryAsync<Libro>(query);
    }



    
}