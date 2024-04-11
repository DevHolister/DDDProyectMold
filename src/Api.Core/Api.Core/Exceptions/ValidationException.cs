using FluentValidation.Results;

namespace Api.Core.Exceptions;

public class ValidationException : Exception
{
    public List<string> Errors { get; }
    public ValidationException() : base("Se han producido uno o más errores de validación.")
    {
        Errors = new List<string>();
    }
    public ValidationException(IEnumerable<ValidationFailure> exceptions) : this()
    {
        foreach (var item in exceptions)
        {
            Errors.Add(item.ErrorMessage);
        }
    }
}
