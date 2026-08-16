namespace GESTORDEBIBLIOTECA.Features.Libro.DTO;

public class LibroResponseDto
{
    public int Id{get;set;}
    public string Titulo{get;set;} = string.Empty;
    public string Autor{get;set;} = string.Empty;
    public string ISBN{get;set;} = string.Empty;
    public int CantidadDisponible{get;set;}
}