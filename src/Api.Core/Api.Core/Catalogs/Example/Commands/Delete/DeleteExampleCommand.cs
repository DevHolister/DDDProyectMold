using ErrorOr;
using MediatR;

namespace Api.Core.Catalogs.Example.Commands.Delete;

public class DeleteExampleCommand : IRequest<ErrorOr<bool>>
{
    public Guid ExampleId { get; set; }
}
