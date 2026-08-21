namespace GESTORDEBIBLIOTECA.Features.Prestamos.Model;

public class Prestamo
{
    public int Id { get; set; }
    public int SocioId { get; set; }
    public int LibroId { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }
}
