using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GESTORDEBIBLIOTECA.Features.Excepciones;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler (ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Ocurrio un error no controlado {mensaje}", exception.Message);

        var statusCode  = (int)HttpStatusCode.InternalServerError; 
        var title = "Error interno del servidor";
        var detail = exception.Message;

        if(exception is BussinesException bussinessException)
        {
            statusCode = (int)bussinessException.StatusCode;
            title = "Error de negocio";
        }
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = context.Request.Path
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }

}   


