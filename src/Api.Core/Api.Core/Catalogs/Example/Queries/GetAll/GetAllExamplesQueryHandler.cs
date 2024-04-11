using Api.Core.Catalogs.Example.Specifications;
using Api.Core.Common.Interfaces.Persistence;
using Api.Core.Common.ModelsDto;
using Api.Core.Common.ModelsDto.Example;
using Api.Domain.Entities.Catalogs.Example;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Core.Catalogs.Example.Queries.GetAll;

internal class GetAllExamplesQueryHandler : IRequestHandler<GetAllExamplesQuery, ErrorOr<PaginatedList<ExampleDto>>>
{
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllExamplesQueryHandler> _logger;
    private readonly IRepository<CatExample> _repository;

    public GetAllExamplesQueryHandler(IMapper mapper,
        ILogger<GetAllExamplesQueryHandler> logger,
        IRepository<CatExample> repository)
    {
        _mapper = mapper;
        _logger = logger;
        _repository = repository;
    }

    public async Task<ErrorOr<PaginatedList<ExampleDto>>> Handle(GetAllExamplesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            //throw new NotImplementedException();
            var items = await _repository.ListAsync(new ExampleSpecification(request.page, request.pageSize, request.Name!, true));
            var count = await _repository.CountAsync(new ExampleSpecification(request.page, request.pageSize, request.Name!, false)); //users.Count;
            var itemsLst = _mapper.Map<List<ExampleDto>>(items);
            return new PaginatedList<ExampleDto>(itemsLst, count, request.page, request.pageSize);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Domain.Common.Errors.Errors.Common.ServerError;
        }
    }
}
