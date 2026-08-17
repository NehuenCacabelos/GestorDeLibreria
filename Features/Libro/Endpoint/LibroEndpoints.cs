using GESTORDEBIBLIOTECA.Features.Libro.Service;
using GESTORDEBIBLIOTECA.Features.Libro.DTO;

public static class LibroEndpoints
{
    public static void MapLibroEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/libros").WithTags("Libros");

        group.MapGet("/", async (ILibroService service) =>
        {
            var libros = await service.GetAllLibros();
            return Results.Ok(libros);
        });

        group.MapGet("/{id:int}", async (int id, ILibroService service) =>
        {
            var libro = await service.GetLibroById(id);
            return libro is not null? Results.Ok(libro) : Results.NotFound();
        });

        group.MapPost("/", async (LibroCreateDto dto, ILibroService service) =>
        {
            var nuevoLibro = await service.CreateLibro(dto);
            return Results.Created($"/api/libros/{nuevoLibro.Id}", nuevoLibro);
        });

        group.MapPut("/{id:int}", async (int id, LibroUpdateDto dto, ILibroService service)=>
        {
            var libro = await service.UpdateLibro(id, dto);
            return libro ? Results.NoContent() : Results.NotFound();
        });

        group.MapDelete("/{id:int}", async (int id, ILibroService service) =>
        {
            var eliminado = await service.DeleteLibro(id);
            return eliminado ? Results.NoContent() : Results.NotFound();
        });



    }
}