using GESTORDEBIBLIOTECA.Features.Socio.Service;
using GESTORDEBIBLIOTECA.Features.Socio.DTO;

namespace GESTORDEBIBLIOTECA.Features.Socio.Endopoint;

public static class SocioEndpoints
{
    public static void MapSocioEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/socios").WithTags("Socios");
        
        group.MapGet("/", async (ISocioService service) =>
        {
            var socios = await service.GetAllSocios();
            return Results.Ok(socios);
        });

        group.MapPost("/", async(SocioCreateDto dto, ISocioService service) =>
        {
           var nuevoSocio = await service.CreateSocio(dto);
           return Results.Created($"/api/socios/{nuevoSocio.Id}", nuevoSocio);
        });
    }
}