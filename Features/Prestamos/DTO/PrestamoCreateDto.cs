using System.ComponentModel.DataAnnotations;

namespace GESTORDEBIBLIOTECA.Features.Prestamos.DTO;

public class PrestamoCreateDto
{
    [Range(1, int.MaxValue, ErrorMessage = "El socio es obligatorio.")]
    public int SocioId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "El libro es obligatorio.")]
    public int LibroId { get; set; }

    [Required(ErrorMessage = "La fecha de préstamo es obligatoria.")]
    public DateTime FechaPrestamo { get; set; }
}
