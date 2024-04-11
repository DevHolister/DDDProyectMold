using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.Common.Http;

namespace webapi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        var firstError = errors[0];
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };
        return Problem(statusCode: statusCode, title: firstError.Description);
    }

    protected IActionResult DownloadFile(byte[] file, string contentType, string fileName)
    {
        if (file == null || file.Length <= 0)
            return NotFound(new
            {
                Data = string.Empty,
                Success = false,
                Message = "Archivo no encontrado",
                Code = StatusCodes.Status404NotFound
            });

        return File(file, contentType, fileName);
    }
}
