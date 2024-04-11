using Ardalis.Specification;

namespace Api.Core.Common.Interfaces.Persistence;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
}
