using Api.Core.Catalogs.Example.Specifications;
using Api.Core.Common.Interfaces.Persistence;
using Api.Core.Common.ModelsDto.Example;
using Api.Core.Common.ModelsDto;
using Api.Domain.Entities.Catalogs.Example;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Core.Catalogs.Example.Commands.Update;

internal class UpdateExampleCommandHandler : IRequestHandler<UpdateExampleCommand, ErrorOr<Guid>>
{
    private readonly IRepository<CatExample> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateExampleCommandHandler> _logger;

    public UpdateExampleCommandHandler(IRepository<CatExample> repository,
        IMapper mapper,
        ILogger<UpdateExampleCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<ErrorOr<Guid>> Handle(UpdateExampleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var item = await _repository.FirstOrDefaultAsync(new ExampleSpecification(request.ExampleId!));
            if (item == null || !item.Visible)
            {
                return Errors.Errors.Example.ElementNotFoud;
            }

            var lstItems = await _repository.ListAsync();
            if (lstItems.Any(x => x.Name.ToUpper() == request.Name.ToUpper() && x.ExampleId != request.ExampleId))
            {
                return Errors.Errors.Example.DuplicateName;
            }

            var example = _mapper.Map<CatExample>(request);
            await _repository.UpdateAsync(example);
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

