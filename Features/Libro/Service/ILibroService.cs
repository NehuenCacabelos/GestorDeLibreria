using GESTORDEBIBLIOTECA.Feature.Libro.DTO;

namespace GESTORDEBIBLIOTECA.Features.Libro.Service;

public interface ILibroService
{
    Task<IEnumerable<LibroResponseDto>> GetAllLibros();
    Task<LibroResponseDto?> GetLibroById(int id);
    Task<LibroResponseDto> CreateLibro(LibroCreateDto libroCreateDto);
    Task<bool> LibroUpdate(int id, LibroUpdateDto libroUpdateDto);
    Task<bool> DeleteLibro(int id);
}