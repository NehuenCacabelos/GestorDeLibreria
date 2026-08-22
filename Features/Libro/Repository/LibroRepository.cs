using System.Data;

namespace GESTORDEBIBLIOTECA.Features.Libro.Repository;

using Dapper; 
using GESTORDEBIBLIOTECA.Features.Libro.Model;

public class LibroRepository : ILibroRepository
{
    private readonly IDbConnection _connection;

    public LibroRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<IEnumerable<Libro>> GetAllLibros()
    {
        var query = "SELECT id, titulo, autor, isbn, cantidaddisponible AS CantidadDisponible FROM libros";
        return await _connection.QueryAsync<Libro>(query);
    }

    public async Task<Libro?> GetLibroById(int id)
    {
        var query = "SELECT id, titulo, autor, isbn, cantidaddisponible AS CantidadDisponible FROM libros WHERE id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<Libro>(query, new{Id = id});
    }

    public async Task<Libro> CreateLibro(Libro libro)
    {
        var sql = @"
        INSERT INTO libros (titulo, autor, isbn, cantidaddisponible)
        VALUES (@Titulo, @Autor, @ISBN, @CantidadDisponible)
        RETURNING id;";
        var id = await _connection.QuerySingleAsync<int>(sql, libro);
        libro.Id = id;
        return libro;
    }

    public async Task<bool> UpdateLibro (int id, Libro libro)
    {
        var query = "UPDATE libros SET titulo = @Titulo, autor = @Autor, isbn = @ISBN, cantidaddisponible = @CantidadDisponible WHERE id = @Id";

        libro.Id = id;
        var rowsAffected = await _connection.ExecuteAsync(query, libro);
        return rowsAffected > 0;     
    }

    public async Task<bool> DeleteLibro(int id)
    {
        var query = "DELETE FROM Libros WHERE id = @Id";
        var rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
        return rowsAffected > 0;
    }

    public async Task<bool> ExistISBN (string isbn)
    {
        var query = "SELECT COUNT(1) FROM Libros WHERE ISBN = @isbn;";
        var count = await _connection.ExecuteScalarAsync<int>(query, new {isbn});
        return count > 0;
    }
    public async Task<bool> ExistISBNconID(string isbn, int id)
    {
        var query = "SELECT COUNT(1) FROM Libros WHERE  ISBN = @isbn AND id <> @id;";
        var count = await _connection.ExecuteScalarAsync<int>(query, new {id});
        return count > 0;
    }

}