namespace GESTORDEBIBLIOTECA.Features.Libro.DTO;

public class LibroUpdateDto
{
    public string Titulo{get;set;} = string.Empty;
    public string Autor{get;set;} = string.Empty;
    public string ISBN{get;set;} = string.Empty;
    public int CantidadDisponible{get;set;}
}