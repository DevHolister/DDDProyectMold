using Api.Core.Common.ModelsDto;
using Api.Core.Common.ModelsDto.Example;
using ErrorOr;
using MediatR;

namespace Api.Core.Catalogs.Example.Queries.GetById;

public record GetExampleByIdQuery(Guid? Id) : IRequest<ErrorOr<ExampleDto>>;
