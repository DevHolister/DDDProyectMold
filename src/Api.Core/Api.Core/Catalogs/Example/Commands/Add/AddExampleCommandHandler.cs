using Api.Core.Catalogs.Example.Specifications;
using Api.Core.Common.Interfaces.Persistence;
using Api.Domain.Entities.Catalogs.Example;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Core.Catalogs.Example.Commands.Add;

internal class AddExampleCommandHandler : IRequestHandler<AddExampleCommand, ErrorOr<Guid>>
{
    private readonly IRepository<CatExample> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<AddExampleCommandHandler> _logger;

    public AddExampleCommandHandler(IRepository<CatExample> repository,
        IMapper mapper,
        ILogger<AddExampleCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<ErrorOr<Guid>> Handle(AddExampleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var item = await _repository.FirstOrDefaultAsync(new ExampleSpecification(request.Name!));
            if (item != null && item.Name.ToUpper().Equals(request.Name.ToUpper()))
            {
                return Errors.Errors.Example.DuplicateName;
            }

            var example = _mapper.Map<CatExample>(request);
            await _repository.AddAsync(example);
            await _repository.SaveChangesAsync(cancellationToken);

            return example.ExampleId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Domain.Common.Errors.Errors.Common.ServerError;
        }
    }
}
