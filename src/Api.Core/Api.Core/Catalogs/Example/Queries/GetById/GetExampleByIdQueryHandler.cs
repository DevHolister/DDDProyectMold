using Api.Core.Catalogs.Example.Specifications;
using Api.Core.Common.Interfaces.Persistence;
using Api.Core.Common.ModelsDto;
using Api.Core.Common.ModelsDto.Example;
using Api.Domain.Entities.Catalogs.Example;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Core.Catalogs.Example.Queries.GetById;

internal class GetExampleByIdQueryHandler : IRequestHandler<GetExampleByIdQuery, ErrorOr<ExampleDto>>
{
    private readonly IRepository<CatExample> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetExampleByIdQueryHandler> _logger;
    public GetExampleByIdQueryHandler(IRepository<CatExample> repository,
        IMapper mapper,
        ILogger<GetExampleByIdQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ErrorOr<ExampleDto>> Handle(GetExampleByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var item = await _repository.FirstOrDefaultAsync(new ExampleSpecification((Guid)request.Id!));
            if (item == null)
            {
                return Domain.Common.Errors.Errors.Common.NotFound;
            }
            var itemCatalog = _mapper.Map<ExampleDto>(item);
            return itemCatalog;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Domain.Common.Errors.Errors.Common.ServerError;
        }
    }
}
