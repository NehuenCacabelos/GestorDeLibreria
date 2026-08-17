namespace GESTORDEBIBLIOTECA.Features.Excepciones;

public class ConflictException : BussinesException
{
    public ConflictException(string message) : base(message, 409){}

}
public class NotFoundException : BussinesException
{
    public NotFoundException(string message) : base(message, 404){}

}
public class BadRequestException : BussinesException
{
    public BadRequestException(string message) : base(message, 400){}
}
