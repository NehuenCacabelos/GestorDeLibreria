namespace GESTORDEBIBLIOTECA.Features.Excepciones;

public abstract class BussinesException : Exception
{
    public int StatusCode { get; set; }
    protected BussinesException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}