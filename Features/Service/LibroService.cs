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





}
