namespace GESTORDEBIBLIOTECA.Feature.Libro.DTO;

using GESTORDEBIBLIOTECA.Feature.Libro.Model;
public static class LibroMappingExtensions
{
    public static Libro ToEntity(this LibroCreateDto libroCreateDto)
    {
        return new Libro
        {
            Titulo = libroCreateDto.Titulo,
            Autor = libroCreateDto.Autor,
            ISBN = libroCreateDto.ISBN,
            CantidadDisponible = libroCreateDto.CantidadDisponible
        };
    }

    public static LibroResponseDto ToResponse(this Libro libro)
    {
        return new LibroResponseDto
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            Autor = libro.Autor,
            ISBN = libro.ISBN,
            CantidadDisponible = libro.CantidadDisponible
        };
   }

    public static void UpdateEntity(this LibroUpdateDto libroUpdateDto, Libro libro)
    {
        libro.Titulo = libroUpdateDto.Titulo;
        libro.Autor = libroUpdateDto.Autor;
        libro.ISBN = libroUpdateDto.ISBN;
        libro.CantidadDisponible = libroUpdateDto.CantidadDisponible;
    }





}
