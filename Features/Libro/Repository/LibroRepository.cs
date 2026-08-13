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

    public async Task<Libro> CreateLibro(Libro libro)
    {
        var query = "INSERT INTO Libros (titulo, autor, ISBN, cantidad_disponible) VALUES (@titulo, @Autor, @ISBN, @CantidadDisponible) RETURNING id)";
        var id = await _connection.QuerySingleAsync<int>(query, libro);
        libro.Id = id;
        return libro;
    }

    public async Task<bool> LibroUpdate (int id, Libro libro)
    {
        var query = "UPDATE libros SET titulo = @Titulo, autor = @Autor, isbn = @ISBN, cantidad_disponible = @CantidadDisponible WHERE id = @Id";
        var rowsAffected = await _connection.ExecuteAsync(query, new { libro.Titulo, libro.Autor, libro.ISBN, libro.CantidadDisponible, Id = id });
        return rowsAffected > 0;     
    }

    public async Task<bool> DeleteLibro(int id)
    {
        var query = "DELETE FROM Libros WHERE id = @Id";
        var rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
        return rowsAffected > 0;
    }

    
}