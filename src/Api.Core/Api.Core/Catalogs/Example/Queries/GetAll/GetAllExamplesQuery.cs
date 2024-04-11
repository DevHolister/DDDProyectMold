using Api.Core.Common.ModelsDto;
using Api.Core.Common.ModelsDto.Example;
using ErrorOr;
using MediatR;

namespace Api.Core.Catalogs.Example.Queries.GetAll;

public record GetAllExamplesQuery(string? Name, int page = 1, int pageSize = 20) : IRequest<ErrorOr<PaginatedList<ExampleDto>>>;
