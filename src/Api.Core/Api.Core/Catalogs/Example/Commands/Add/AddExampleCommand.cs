using ErrorOr;
using MediatR;

namespace Api.Core.Catalogs.Example.Commands.Add;

public class AddExampleCommand : IRequest<ErrorOr<Guid>>
{
    public string Name { get; set; }
}
