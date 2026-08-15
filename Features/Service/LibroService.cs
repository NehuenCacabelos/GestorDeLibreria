using System.ComponentModel.Design;
using GESTORDEBIBLIOTECA.Feature.Libro.DTO;
using GESTORDEBIBLIOTECA.Feature.Libro.Model;
using GESTORDEBIBLIOTECA.Features.Libro.Repository;

namespace GESTORDEBIBLIOTECA.Features.Libro.Service;

public class LibroService : ILibroService
{
   private readonly ILibroRepository _repository;

    public LibroService (ILibroRepository repository)
    {
        _repository = repository;
    }

   public async Task<IEnumerable<LibroResponseDto>> GetAllLibros()
   {
      var libros = await _repository.GetAllLibros();
      return libros.Select(l => l.ToResponse());
   }

   public async Task<LibroResponseDto?> GetLibroById (int id)
   {
      var libro = await _repository.GetLibroById(id);
      return libro?.ToResponse();
   }

   public async Task<LibroResponseDto> CreateLibro (LibroCreateDto libroCreateDto)
   {
      var libroEntity = libroCreateDto.ToEntity();
      var libroNuevo = await _repository.CreateLibro(libroEntity);

      return libroNuevo.ToResponse();
   }

   




}
