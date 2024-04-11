using ErrorOr;

namespace Api.Domain.Common.Errors;

public static partial class Errors
{
    public static class Common
    {
        public static Error ServerError => Error.Failure(
            code: "Common.ServerError",
            description: "Surgio un error al procesar la petición.");

        public static Error NotFound => Error.NotFound(
            code: "Common.NotFound",
            description: "No existe el recurso solicitado.");

        public static Error NotAuthenticated => Error.Conflict(
            code: "Common.NotAuthenticated",
            description: "Usuario no autenticado.");
        public static Error Duplicated => Error.Validation(
           code: "Common.Duplicated",
           description: "Ya existe un registro en la base de datos");
    }
}
