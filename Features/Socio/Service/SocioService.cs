using GESTORDEBIBLIOTECA.Features.Socio.DTO;
using GESTORDEBIBLIOTECA.Features.Socio.Model;
using GESTORDEBIBLIOTECA.Features.Socio.Repository;

namespace GESTORDEBIBLIOTECA.Features.Socio.Service;

public class SocioService : ISocioService
{
    private readonly ISocioRepository _repository;

    public SocioService (ISocioRepository repository)
    {
        _repository = repository;
    }

    public async Task<SocioResponseDto> CreateSocio (SocioCreateDto socioCreateDto)
    {
        var socioEntity = socioCreateDto.ToEntity();
        var socioNuevo = await _repository.CreateSocio(socioEntity);

        return socioNuevo.ToResponse();
    }

    public async Task<IEnumerable<SocioResponseDto>> GetAllSocios()
    {
        var socios = await _repository.GetAllSocios();
        return socios.Select(s => s.ToResponse());
    }
}