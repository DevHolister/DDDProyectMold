using ErrorOr;

namespace Api.Core.Catalogs.Example.Errors;

public static partial class Errors
{
    public static class Example
    {
        public static Error DuplicateName => Error.Conflict(
            code: "Example.DuplicateName",
            description: "Ya existe un elemento con el mismo nombre.");

        public static Error IncorrectFormat => Error.Validation(
            code: "Example.IncorrectFormat",
            description: "El elemento no tiene el formato esperado.");

        public static Error ElementNotFoud => Error.NotFound(
            code: "Example.ElementNotFoud",
            description: "No se encontró el elemento solicitado.");

        public static Error ElementHasAlreadyBeenDeleted => Error.Conflict(
            code: "Example.ElementAlreadyDeleted",
            description: "El elemento ya fue eliminado.");
    }
}
