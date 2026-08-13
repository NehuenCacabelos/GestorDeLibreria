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

    public async Task<Libro?> GetLibroById(int id)
    {
        var query = "SELECT id, titulo, autor, isbn, cantidad_disponible AS CantidadDisponible FROM libros WHERE id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<Libro>(query, new{Id = id});
    }



    
}