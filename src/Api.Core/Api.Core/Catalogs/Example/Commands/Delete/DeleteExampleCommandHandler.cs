using Api.Core.Catalogs.Example.Specifications;
using Api.Core.Common.Interfaces.Persistence;
using Api.Domain.Entities.Catalogs.Example;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Core.Catalogs.Example.Commands.Delete;

internal class DeleteExampleCommandHandler : IRequestHandler<DeleteExampleCommand, ErrorOr<bool>>
{
    private readonly IRepository<CatExample> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteExampleCommandHandler> _logger;

    public DeleteExampleCommandHandler(
        IRepository<CatExample> repository,
        IMapper mapper,
        ILogger<DeleteExampleCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteExampleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var item = await _repository.FirstOrDefaultAsync(new ExampleSpecification(request.ExampleId!));
            if (item == null)
            {
                return Errors.Errors.Example.ElementNotFoud;
            }
            if(item.Visible == false)
            {
                return Errors.Errors.Example.ElementHasAlreadyBeenDeleted;
            }

            item.SoftRemove();//item.Visible = false;
            await _repository.UpdateAsync(item);
            //await _repository.DeleteAsync(item);
            await _repository.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return Domain.Common.Errors.Errors.Common.ServerError;
        }
    }
}
