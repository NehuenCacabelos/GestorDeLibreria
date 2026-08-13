using System.ComponentModel.DataAnnotations;

namespace GESTORDEBIBLIOTECA.Feature.Libro.DTO;

public class LibroCreateDto
{
    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres.")]
    public string Titulo{get;set;} = string.Empty;

    [Required(ErrorMessage = "El autor es obligatorio.")]
    [StringLength(100, ErrorMessage = "El autor no puede tener más de 100 caracteres.")]
    public string autor{get;set;}=string.Empty;

    [Required(ErrorMessage = "El ISBN es obligatorio.")]
    [StringLength(13, ErrorMessage = "El ISBN no puede tener más de 13 caracteres.")]
    public string ISBN{get;set;} = string.Empty;

    [Required(ErrorMessage = "La cantidad disponible es obligatoria.")]
    [Range(0, int.MaxValue, ErrorMessage = "La cantidad disponible debe ser un número entero no negativo.")]
    public int CantidadDisponible{get;set;}
}