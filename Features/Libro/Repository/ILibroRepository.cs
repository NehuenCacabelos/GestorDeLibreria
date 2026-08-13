namespace GESTORDEBIBLIOTECA.Features.Libro.Repository;

using GESTORDEBIBLIOTECA.Feature.Libro.Model;

public interface ILibroRepository
{
    Task<IEnumerable<Libro>> GetAllLibros();
    Task<Libro?> GetLibroById(int id);
    Task<Libro> CreateLibro(Libro libro);
    Task<bool> LibroUpdate(int id, Libro libro);
    Task<bool> DeleteLibro(int id);
}