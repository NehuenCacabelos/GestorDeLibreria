using System.ComponentModel.DataAnnotations;

namespace GESTORDEBIBLIOTECA.Features.Prestamos.DTO;

public class PrestamoUpdateDto
{
    [Required(ErrorMessage = "La fecha de devolución es obligatoria.")]
    public DateTime? FechaDevolucion { get; set; }
}
