using System.ComponentModel.Design;
using GESTORDEBIBLIOTECA.Features.Excepciones;
using GESTORDEBIBLIOTECA.Features.Libro.DTO;
using GESTORDEBIBLIOTECA.Features.Libro.Model;
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
      if (libro is null)
      {
         throw new NotFoundException("Libro no encontrado");
      }
      return libro?.ToResponse();
   }

   public async Task<LibroResponseDto> CreateLibro (LibroCreateDto libroCreateDto)
   {
      var existe = await _repository.ExistISBN(libroCreateDto.ISBN);
      if (existe)
      {
         throw new ConflictException("El ISBN ya existe");
      }

      var libroEntity = libroCreateDto.ToEntity();
      var libroNuevo = await _repository.CreateLibro(libroEntity);

      return libroNuevo.ToResponse();
   }

   public async Task<LibroResponseDto> UpdateLibro (int id, LibroUpdateDto libroUpdateDto)
   {
      var existe = await _repository.GetLibroById(id);
      if (existe is null)
      {
         throw new NotFoundException("Libro no encontrado");
      }
      var existeConISBN = await _repository.ExistISBNconID(libroUpdateDto.ISBN, id);
      if (existeConISBN)
      {
         throw new ConflictException("El ISBN ya existe");
      }
      var libroEntity = libroUpdateDto.ToEntity();
      libroEntity.Id = id;

      await _repository.UpdateLibro(id, libroEntity);

      return libroEntity.ToResponse();
   }

   public async Task<bool> DeleteLibro(int id)
   {
      return await _repository.DeleteLibro(id);
   }





}
