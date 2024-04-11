using ErrorOr;
using MediatR;

namespace Api.Core.Catalogs.Example.Commands.Update;

public class UpdateExampleCommand : IRequest<ErrorOr<Guid>>
{
    public Guid ExampleId { get; set; }
    public string Name { get; set; }
}
