namespace GESTORDEBIBLIOTECA.Features.Prestamos.Repository;

using GESTORDEBIBLIOTECA.Features.Prestamos.Model;

public interface IPrestamoRepository
{
    Task<IEnumerable<Prestamo>> GetAllPrestamos();
    Task<Prestamo?> GetPrestamoById(int id);
    Task<Prestamo> CreatePrestamo(Prestamo prestamo);
    Task<bool> UpdatePrestamo(int id, Prestamo prestamo);
    Task<bool> DeletePrestamo(int id);
}
