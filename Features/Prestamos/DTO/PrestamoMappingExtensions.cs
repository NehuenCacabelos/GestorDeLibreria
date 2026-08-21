namespace GESTORDEBIBLIOTECA.Features.Prestamos.DTO;

using GESTORDEBIBLIOTECA.Features.Prestamos.Model;

public static class PrestamoMappingExtensions
{
    public static Prestamo ToEntity(this PrestamoCreateDto prestamoCreateDto)
    {
        return new Prestamo
        {
            SocioId = prestamoCreateDto.SocioId,
            LibroId = prestamoCreateDto.LibroId,
            FechaPrestamo = prestamoCreateDto.FechaPrestamo
        };
    }

    public static PrestamoResponseDto ToResponse(this Prestamo prestamo)
    {
        return new PrestamoResponseDto
        {
            Id = prestamo.Id,
            SocioId = prestamo.SocioId,
            LibroId = prestamo.LibroId,
            FechaPrestamo = prestamo.FechaPrestamo,
            FechaDevolucion = prestamo.FechaDevolucion
        };
    }

    public static void UpdateEntity(this PrestamoUpdateDto prestamoUpdateDto, Prestamo prestamo)
    {
        prestamo.FechaDevolucion = prestamoUpdateDto.FechaDevolucion;
    }
}
