namespace GESTORDEBIBLIOTECA.Features.Socio.Repository;
using GESTORDEBIBLIOTECA.Features.Socio.Model;
public interface ISocioRepository
{
    Task<Socio> CreateSocio(Socio socio);
    Task<IEnumerable<Socio>> GetAllSocios();
}