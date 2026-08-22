namespace GESTORDEBIBLIOTECA.Features.Libro.Repository;

using GESTORDEBIBLIOTECA.Features.Libro.Model;

public interface ILibroRepository
{
    Task<IEnumerable<Libro>> GetAllLibros();
    Task<Libro?> GetLibroById(int id);
    Task<Libro> CreateLibro(Libro libro);
    Task<bool> UpdateLibro(int id, Libro libro);
    Task<bool> DeleteLibro(int id);
    Task<bool> ExistISBN (string isbn);
    Task<bool> ExistISBNconID (string isbn, int id);
}