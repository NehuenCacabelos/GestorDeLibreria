using GESTORDEBIBLIOTECA.Features.Socio.DTO;

namespace GESTORDEBIBLIOTECA.Features.Socio.Service;

public interface ISocioService
{
    Task<SocioResponseDto> CreateSocio (SocioCreateDto socioCreateDto);
    Task<IEnumerable<SocioResponseDto>> GetAllSocios();
}