namespace GESTORDEBIBLIOTECA.Features.Socio.DTO;
using GESTORDEBIBLIOTECA.Features.Socio.Model;

public static class SocioMappingExtensions
{
    public static Socio ToEntity(this SocioCreateDto socioCreateDto)
    {
        return new Socio
        {
            NombreCompleto = socioCreateDto.NombreCompleto,
            Email = socioCreateDto.Email
            
        };
    }

    public static SocioResponseDto ToResponse(this Socio socio)
    {
        return new SocioResponseDto
        {
            Id = socio.id,
            NombreCompleto = socio.NombreCompleto,
            Email = socio.Email
        };
    }

}

