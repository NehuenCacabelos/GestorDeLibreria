using System.ComponentModel.DataAnnotations;

namespace GESTORDEBIBLIOTECA.Features.Socio.DTO;

public class SocioCreateDto
{
    [Required (ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no pued tener mas de 100 caracteres.")]
    public string NombreCompleto{get;set;}

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El email no es valido.")]
    public string Email{get;set;}
}